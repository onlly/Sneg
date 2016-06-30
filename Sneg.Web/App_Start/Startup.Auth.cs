using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Sneg.Web.Authentication;

namespace Sneg.Web.App_Start
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider =
                    new AuthorizationOAuthServerProvider(ConfigurationManager.AppSettings["clientId"],
                        ConfigurationManager.AppSettings["clientSecret"]),
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);
            app.Use<UserAuthenticationMiddleware>();
        }
    }
}