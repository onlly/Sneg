using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Sneg.Common.DI;
using Sneg.Web.DI.Resolvers;

namespace Sneg.Web.DI.Installers
{
    public class ComponentResolverInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IComponentResolver>().Instance(new WindsorComponentResolver(container)).LifestyleTransient());
            container.Register(Component.For<IScopedComponentResolver>().Instance(new WindsorScopedComponentResolver(container)).LifestyleTransient());
        }
    }
}