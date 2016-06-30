using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneg.Web.DI
{
    public class RegularInstallersFactory : InstallerFactory
    {
        public override IEnumerable<Type> Select(IEnumerable<Type> installerType)
        {
            return installerType;
        }
    }
}