using Sneg.Common.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Sneg.Web.DI
{
    public class CustomHttpActivator : IHttpControllerActivator
    {
        private readonly IComponentResolver _componentResolver;

        public CustomHttpActivator(IComponentResolver componentResolver)
        {
            if (componentResolver == null)
                throw new ArgumentNullException("componentResolver");
            _componentResolver = componentResolver;
        }
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController)_componentResolver.Resolve(controllerType);
            request.RegisterForDispose(new Release(()=> _componentResolver.Release(controller));

            return controller;
        }

        private class Release :IDisposable
        {
            private readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }
            public void Dispose()
            {
                _release();
            }
        }
    }
}