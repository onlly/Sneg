using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Castle.DynamicProxy.Generators.Emitters;
using Sneg.Common.Identity;
using Sneg.Web.Attributes;

namespace Sneg.Web.Controllers
{
    [ApiAuthorize]
    public class BaseApiController : ApiController
    {
            public UserPrincipal CurrentUser
            {
                get
                {
                    var identity = HttpContext.Current.GetOwinContext().Authentication.User.Identity as ClaimsIdentity;
                    var userIdentity = new UserIdentity(identity);
                    var userPrincipal = new UserPrincipal(new List<UserIdentity> {userIdentity});
                    return userPrincipal;
                }
            }
	}
}