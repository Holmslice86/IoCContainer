using IoCContainer.Host.Controllers;
using IoCContainer.Host.Interfaces;
using IoCContainer.Host.Models;
using System.Web.Mvc;

namespace IoCContainer.Host.App_Start
{
    public static class Bootstrapper
    {

        public static void Bootstrap(MyContainer container)
        {
            container.Register<IControllerFactory, MyControllerFactory>();
            container.Register<HomeController>();
            container.Register<ICalculator, Calculator>();
            container.Register<IEmailClient, EmailClient>();
            container.Register<IEmailService, EmailService>();
        }

    }
}