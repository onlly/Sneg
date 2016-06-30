using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Sneg.Web.Controllers;

namespace Sneg.Web.DI.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<BaseApiController>()
                .BasedOn<BaseApiController>()
                .If(Component.IsInSameNamespaceAs<BaseApiController>(true))
                .If(type => type.Name.EndsWith("Controller"))
                .WithService.Self()
                .Configure(c => c.LifestyleTransient()));

            container.Register(Classes.FromAssemblyContaining<HomeController>()
                .Where(x => x.Name.EndsWith("Controller") && !x.Name.EndsWith("ApiController"))
                .Configure(c => c.LifestyleTransient()));
        }
    }
}