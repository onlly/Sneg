using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Sneg.Data.Repositories.Implementation;
using Sneg.Data.Repositories.Interfaces;
using Sneg.Service.Implementation;
using Sneg.Service.Interfaces;

namespace Sneg.Web.DI.Installers
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<LexCvbDbContext>().ImplementedBy<LexCvbDbContext>()
                    .DependsOn(Dependency.OnValue("connectionString", "Database"))
                    .LifestylePerWebRequest());

            container.Register(
                  Classes.FromAssemblyContaining(typeof(UserRepository))
                      .BasedOn(typeof(IRepository<>))
                      .WithService.FromInterface(typeof(IRepository<>))
                      .LifestyleTransient());

            container.Register(
                 Classes.FromAssemblyContaining(typeof(UserService))
                     .BasedOn(typeof(IServiceBase<>))
                     .WithService.FromInterface(typeof(IServiceBase<>))
                     .LifestyleTransient());
        }
    }
}