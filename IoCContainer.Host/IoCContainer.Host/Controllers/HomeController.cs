using IoCContainer.Host.Interfaces;
using System.Web.Mvc;

namespace IoCContainer.Host.Controllers
{
    public class HomeController : Controller
    {

        private ICalculator _calculator;
        private IEmailService _emailService;

        public HomeController(ICalculator calc, IEmailService email)
        {
            _calculator = calc;
            _emailService = email;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}