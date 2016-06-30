using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using System.Web;
using Sneg.Common.DI;

namespace Sneg.Web.DI.Resolvers
{
    public class WindsorComponentResolver : IComponentResolver
    {
        protected internal IWindsorContainer Container { get; private set; }

        public WindsorComponentResolver(IWindsorContainer container)
        {
            this.Container = container;
        }

        public T Resolver<T>()
        {
            return this.Container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return this.Container.Resolve(type);
        }

        public void Release(object instance)
        {
            this.Container.Release(instance);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return this.Container.ResolveAll<T>();
        }

        public IEnumerable<object> ResolveAll(Type t)
        {
            return this.Container.ResolveAll(t).Cast<object>();
        }
    }
}