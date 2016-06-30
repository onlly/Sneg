using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Sneg.Service.Interfaces;
using Sneg.Service.Models;

namespace Sneg.Web.Authentication
{
    public class IdentityUserManager : UserManager<UserDto, int>
    {
        public IdentityUserManager(IUserService userService) : base(userService)
        {
            
        }
    }
}