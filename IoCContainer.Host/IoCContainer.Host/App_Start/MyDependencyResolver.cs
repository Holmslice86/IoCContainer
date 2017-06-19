using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoCContainer.Host.App_Start
{
    public class MyDependencyResolver : IDependencyResolver
    {
        public MyDependencyResolver()
        {
            var c = new MyContainer();
        }


        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}