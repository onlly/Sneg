using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Common.DI
{
    public static class ServiceLocator
    {
        public static T Resolve<T>()
        {
            return Resolver.Resolve<T>();
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return Resolver.ResolveAll<T>();
        }

        public static object Resolve(Type type)
        {
            return Resolver.Resolve(type);
        }

        public static void Release(object instance)
        {
            Resolver.Release(instance);
        }

        public static void SetResolver(IComponentResolver resolver)
        {
            Resolver = resolver;
        }

        public static void SetScopedResolver(IScopedComponentResolver scopedResolver)
        {
            ScopedResolver = scopedResolver;
        }

        public static IComponentResolver Resolver { get; private set; }
        public static IScopedComponentResolver ScopedResolver { get; private set; }
    }
}
