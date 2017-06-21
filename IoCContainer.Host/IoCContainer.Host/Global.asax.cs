using IoCContainer.Host.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IoCContainer.Host
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private MyContainer _container;

        protected void Application_Start()
        {
            _container = new MyContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Bootstrap(_container);
            ControllerBuilder.Current.SetControllerFactory(new MyControllerFactory(_container));
        }
    }
}
