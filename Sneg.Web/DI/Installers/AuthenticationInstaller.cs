using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Sneg.Web.Authentication;

namespace Sneg.Web.DI.Installers
{
    public class AuthenticationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            //todo fix it 
            //container.Register(Component.For<UserPrincipal>().UsingFactoryMethod(() => 
            //    HttpContext.Current.GetOwinContext().Authentication.User as UserPrincipal).LifestyleTransient());
            //container.Register(Component.For<UserIdentity>().UsingFactoryMethod(() => 
            //    HttpContext.Current.GetOwinContext().Authentication.User.Identity as UserIdentity).LifestyleTransient());

            container.Register(Component.For<IdentityUserManager>().ImplementedBy<IdentityUserManager>().LifestyleTransient());
            container.Register(Component.For<IdentitySignInManager>().ImplementedBy<IdentitySignInManager>().LifestyleTransient());
        }
    }
}