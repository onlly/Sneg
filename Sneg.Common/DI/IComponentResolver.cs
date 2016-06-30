using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Common.DI
{
    public interface IComponentResolver
    {
        T Resolve<T>();

        object Resolve(Type type);

        void Release(object instance);

        IEnumerable<T> ResolveAll<T>();

        IEnumerable<object> ResolveAll(Type t);
    }
}
