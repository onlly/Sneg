using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Owin;
using Sneg.Common.DI;
using Sneg.Web.DI;
using Sneg.Web.DI.Resolvers;

namespace Sneg.Web.App_Start
{
    public partial class Startup
    {
        public void ConfigureDi(IAppBuilder app)
        {
            var windsor = new WindsorContainer();
            windsor.Kernel.Resolver.AddSubResolver(new ArrayResolver(windsor.Kernel, true));
            windsor.Kernel.Resolver.AddSubResolver(new ListResolver(windsor.Kernel, true));
            windsor.Kernel.Resolver.AddSubResolver(new CollectionResolver(windsor.Kernel, true));

            windsor.Install(FromAssembly.This(new RegularInstallersFactory()));
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(windsor.Kernel));
            var resolver = new WindsorComponentResolver(windsor);
            ServiceLocator.SetResolver(resolver);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new CustomHttpActivator(ServiceLocator.Resolve<IScopedComponentResolver>()));
        }
    }
}