using GuvercinApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GuvercinApp.Controllers
{
    public class AccController : Controller
    {
        private readonly Guvercin.DataAccessLayer.DataContext _context;
        public AccController()
        {
            _context = new Guvercin.DataAccessLayer.DataContext();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _context.Kullanicilar.SingleOrDefault(u => u.KullaniciAdi == username && u.Sifre == password);
            if (user != null)
            {
                Session["KullaniciId"] = user.KullaniciId;
                FormsAuthentication.SetAuthCookie(user.KullaniciAdi, false);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("KullaniciId");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}