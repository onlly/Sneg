using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Sneg.Common.Enums;

namespace Sneg.Common.Extensions
{
    public static class RoleExtensions
    {
        public static RoleEnum GetRole(this string roleName)
        {
            RoleEnum role;

            if (!Enum.TryParse(roleName, out role))
                throw new NotSupportedException(string.Format("Role not found: {0}", roleName));

            return role;
        }

        public static IEnumerable<RoleEnum> GetRoles(this ClaimsIdentity identity)
        {
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value.GetRole());
            return roles;
        }

        public static IEnumerable<RoleEnum> GetRoles(this ClaimsPrincipal principal)
        {
            if (!(principal.Identity is ClaimsIdentity))
                return new List<RoleEnum>();

            var roles = ((ClaimsIdentity)principal.Identity).GetRoles();
            return roles;
        }
    }
}
