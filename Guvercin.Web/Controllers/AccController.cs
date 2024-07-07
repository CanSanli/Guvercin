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

        [HttpGet]
        public ActionResult Profile()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Login", "Acc");
            }
            // Kullanıcı Id'sini Session'dan al
            int kullaniciId = (int)Session["KullaniciId"];

            // Kullanıcıyı ve ilişkili bilgileri getir
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.KullaniciId == kullaniciId);
            if (kullanici == null)
            {
                return HttpNotFound("Kullanıcı bulunamadı.");
            }

            if (kullanici.KullaniciTipi == "bireysel")
            {
                var bireyselKullanici = _context.BireyselKullanicilar.FirstOrDefault(b => b.KullaniciId == kullaniciId);
                if (bireyselKullanici == null)
                {
                    return HttpNotFound("Bireysel kullanıcı bulunamadı.");
                }

                // ViewModel oluştur
                var model = new ProfileViewModel
                {
                    Kullanici = kullanici,
                    BireyselKullanici = bireyselKullanici
                };

                return View(model);
            }
            else if (kullanici.KullaniciTipi == "kurumsal")
            {
                var kurumsalKullanici = _context.KurumsalKullanicilar.FirstOrDefault(k => k.KullaniciId == kullaniciId);
                if (kurumsalKullanici == null)
                {
                    return HttpNotFound("Kurumsal kullanıcı bulunamadı.");
                }

                // ViewModel oluştur
                var model = new ProfileViewModel
                {
                    Kullanici = kullanici,
                    KurumsalKullanici = kurumsalKullanici
                };

                return View(model);
            }

            return HttpNotFound("Kullanıcı tipi belirlenemedi.");
        }


        [HttpPost]
        public ActionResult SaveProfile(ProfileViewModel model)
        {
            // Kullanıcıyı güncelle
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.KullaniciId == model.Kullanici.KullaniciId);
            if (kullanici == null)
            {
                return HttpNotFound("Kullanıcı bulunamadı.");
            }
            kullanici.KullaniciAdi = model.Kullanici.KullaniciAdi;
            kullanici.Sifre = model.Kullanici.Sifre;
            kullanici.Email = model.Kullanici.Email;
            kullanici.Telefon = model.Kullanici.Telefon;
            kullanici.Adres = model.Kullanici.Adres;

            // Bireysel kullanıcı ise bireysel bilgileri de güncelle
            if (model.Kullanici.KullaniciTipi == "bireysel")
            {
                var bireyselKullanici = _context.BireyselKullanicilar.FirstOrDefault(b => b.KullaniciId == model.Kullanici.KullaniciId);
                if (bireyselKullanici == null)
                {
                    return HttpNotFound("Bireysel kullanıcı bulunamadı.");
                }

                bireyselKullanici.Ad = model.BireyselKullanici.Ad;
                bireyselKullanici.Soyad = model.BireyselKullanici.Soyad;
                bireyselKullanici.DogumTarihi = model.BireyselKullanici.DogumTarihi;
            }
            // Kurumsal kullanıcı ise kurumsal bilgileri de güncelle
            else if (model.Kullanici.KullaniciTipi == "kurumsal")
            {
                var kurumsalKullanici = _context.KurumsalKullanicilar.FirstOrDefault(k => k.KullaniciId == model.Kullanici.KullaniciId);
                if (kurumsalKullanici == null)
                {
                    return HttpNotFound("Kurumsal kullanıcı bulunamadı.");
                }

                kurumsalKullanici.KurumAdi = model.KurumsalKullanici.KurumAdi;
                kurumsalKullanici.VergiNo = model.KurumsalKullanici.VergiNo;
                kurumsalKullanici.KurulusTarihi = model.KurumsalKullanici.KurulusTarihi;
            }

            _context.SaveChanges();

            return RedirectToAction("Profile");
        }
    }
}