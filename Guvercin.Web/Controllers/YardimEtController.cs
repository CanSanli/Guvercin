using GuvercinApp.Models;
using Guvercin.DataAccessLayer;
using System.Linq;
using System.Web.Mvc;

namespace GuvercinApp.Controllers
{
    public class YardimEtController : Controller
    {
        private readonly DataContext _context;

        public YardimEtController()
        {
            _context = new DataContext();
        }

        [HttpGet]
        public ActionResult YardimEt()
        {
            var model = new EtModel
            {
                YardimEt = new YardimEt(),
                YardimTalepleri = _context.YardimTalepleri.ToList()
            };

            ViewBag.YardimTalepleri = _context.YardimTalepleri.Select(y => new { y.YardimTalebiId, y.Aciklama }).ToList();
            ViewBag.Kurumlar = _context.KurumsalKullanicilar.Select(k => new { k.KullaniciId, k.KurumAdi }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YardimEt(EtModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)Session["KullaniciId"];
                model.YardimEt.YardimEdenKullaniciId = currentUserId;

                _context.YardimEts.Add(model.YardimEt);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            ViewBag.YardimTalepleri = _context.YardimTalepleri.Select(y => new { y.YardimTalebiId, y.Aciklama }).ToList();
            ViewBag.Kurumlar = _context.KurumsalKullanicilar.Select(k => new { k.KullaniciId, k.KurumAdi }).ToList();

            model.YardimTalepleri = _context.YardimTalepleri.ToList();
            return View(model);
        }
    }
}
