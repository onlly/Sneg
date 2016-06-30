using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sneg.Web.DI
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this._kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            base.ReleaseController(controller);
            _kernel.ReleaseComponent(controller);

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            IController controller = null;

            try
            {
                controller = (IController)_kernel.Resolve(controllerType);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(
                        string.Format(
                                CultureInfo.CurrentUICulture,
                                "An error occurred when trying to create a controller of type '{0}'. Make sure that IoC container contains all necessary registrations.",
                                new object[] { controllerType }),
                        exception);
            }

            return controller;
        }
    }
}