using Sneg.Common.DI;
using System;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace Sneg.Web.DI.Resolvers
{
    public class WindsorScopedComponentResolver : WindsorComponentResolver, IScopedComponentResolver
    {
        public WindsorScopedComponentResolver(IWindsorContainer conteiner) : base(conteiner)
        {

        }
        public IDisposable BeginScope()
        {
            return Container.BeginScope();
        }
    }
}