using System.Web.Mvc;

namespace GuvercinApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly Guvercin.DataAccessLayer.DataContext _context;
        public HomeController()
        {
            _context = new Guvercin.DataAccessLayer.DataContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["KullaniciId"]==null)
            {
                return RedirectToAction("Login","Acc");
            }
            int userId = (int)Session["KullaniciId"];
            var user = _context.Kullanicilar.Find(userId);
            ViewBag.User = user;
            return View();
        }

        [HttpGet]
        public ActionResult Logins()
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
