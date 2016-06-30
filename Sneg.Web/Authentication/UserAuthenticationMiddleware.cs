using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace Sneg.Web.Authentication
{
    public class UserAuthenticationMiddleware : OwinMiddleware
    {
        public UserAuthenticationMiddleware(OwinMiddleware next)
            : base(next)
        {
        }
        public override async Task Invoke(IOwinContext context)
        {
            await IdentityInitializer.SetIdentity(context);
            await Next.Invoke(context);
        }
    }
}