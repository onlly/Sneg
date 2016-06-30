using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Sneg.Common.Identity;

namespace Sneg.Web.Authentication
{
    internal class IdentityInitializer
    {
        public static Task SetIdentity(IOwinContext context)
        {
            var principal = context.Authentication.User;

            UserIdentity userIdentity;

            if (principal != null)
            {
                userIdentity = new UserIdentity(principal.Identity as ClaimsIdentity);
            }
            else
            {
                userIdentity = new UserIdentity(new ClaimsIdentity());
            }
            var user = new UserPrincipal(new List<UserIdentity> {userIdentity});
            context.Authentication.User = user;
            return Task.FromResult(true);
        }
    }
}