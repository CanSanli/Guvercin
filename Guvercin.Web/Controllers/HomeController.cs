using System.Web.Mvc;

namespace GuvercinApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize] //Login check
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegisterPage()
        {
            return View();
        }

        public ActionResult GetHelp()
        {
            return View();
        }
        public ActionResult ProvideHelp()
        {
            return View();
        }
    }
}
