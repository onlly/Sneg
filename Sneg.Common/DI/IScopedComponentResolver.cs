using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Common.DI
{
    public interface IScopedComponentResolver : IComponentResolver
    {
        IDisposable BeginScope();
    }
}
