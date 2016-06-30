using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sneg.Service.Models;

namespace Sneg.Web.Authentication
{
    public class IdentitySignInManager : SignInManager<UserDto, int>
    {
        public IdentitySignInManager(IdentityUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(UserDto user)
        {
            var identity = UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return identity;
        }

        public void SignOut()
        {
            base.AuthenticationManager.SignOut();
        }
    }
}