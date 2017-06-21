using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace IoCContainer.Host.App_Start
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        private readonly MyContainer _myContainer;
        public MyControllerFactory(MyContainer container)
        {
            _myContainer = container;
        }

        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            return _myContainer.Resolve(controllerType) as Controller;
        }
    }
}