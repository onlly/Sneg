using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Sneg.Common.Enums;
using Sneg.Common.Extensions;

namespace Sneg.Common.Identity
{
    public class UserPrincipal : ClaimsPrincipal
    {
        public UserPrincipal(IEnumerable<UserIdentity> identities)
            : base(identities)
        {
            
        }

        public bool IsInRole(RoleEnum role)
        {
            return base.IsInRole(role.ToString());
        }

        public int UserId
        {
            get { return Identity.GetUserId<int>(); }
        }

        public string UserName
        {
            get { return Identity.Name; }
        }

        public IEnumerable<RoleEnum> Roles
        {
            get
            {
                var roles = this.GetRoles();
                return roles;
            }
        }
    }
}
