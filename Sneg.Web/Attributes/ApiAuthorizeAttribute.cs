using Sneg.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Sneg.Web.Attributes
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public ApiAuthorizeAttribute()
        { 
        }
        public ApiAuthorizeAttribute(params RoleEnum[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}