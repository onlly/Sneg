using Microsoft.Owin.Security.OAuth;
using Sneg.Common.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Sneg.Common.Extensions;
using Sneg.Common.Helpers;
using Sneg.Web.Models;

namespace Sneg.Web.Authentication
{
    public class AuthorizationOAuthServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _clientId;
        private readonly string _cleentSecret;

        public AuthorizationOAuthServerProvider(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _cleentSecret = clientSecret;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var userManager = ServiceLocator.Resolve<IdentityUserManager>();
            var user = await userManager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                var identity = await userManager.CreateIdentityAsync(user, OAuthDefaults.AuthenticationType);
                var props = GetPropteries(identity);
                var authenticationTicket = new AuthenticationTicket(identity, props);

                context.Validated(authenticationTicket);
            }
            else
            {
                context.SetError("invalid_grant","Invalid User Id or password");
                context.Rejected();
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string,string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key,property.Value);
            }
            return base.TokenEndpoint(context);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            context.TryGetFormCredentials(out clientId, out clientSecret);

            if (clientId == _clientId && clientSecret == _cleentSecret)
            {
                context.Validated(clientId);
            }
            return base.ValidateClientAuthentication(context);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _clientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }
            return base.ValidateClientRedirectUri(context);
        }

        private AuthenticationProperties GetPropteries(ClaimsIdentity identity)
        {
            var jsonUser = JsonHelper.Serialize(new UserInfoModel
            {
                Id = identity.GetUserId<int>(),
                Name = identity.Name,
                Roles = identity.GetRoles()
            });

            var dictionary = new Dictionary<string, string>
            {
                { "user_data", jsonUser }
            };

            return new AuthenticationProperties(dictionary);
        }
    }
}