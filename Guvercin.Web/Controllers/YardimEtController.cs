using GuvercinApp.Models;
using Guvercin.DataAccessLayer;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using Guvercin.BusinessLayer.Abstract;

namespace GuvercinApp.Controllers
{
    public class YardimEtController : Controller
    {
        private readonly Repository<YardimTalebi> _yardimTalebiRepository = new Repository<YardimTalebi>();
        private readonly Repository<YardimEt> _yardimEtRepository = new Repository<YardimEt>();
        private readonly Repository<KurumsalKullanici> _kurumsalKullaniciRepository = new Repository<KurumsalKullanici>();
        private readonly DataContext _context;

        public YardimEtController()
        {
            _context = new DataContext();
        }

        [HttpGet]
        public ActionResult YardimEt()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Login", "Acc");
            }

            var model = new EtModel
            {
                YardimEt = new YardimEt(),
                YardimTalepleri = _context.YardimTalepleri.ToList()
            };

            var yardimTalepleri = _yardimTalebiRepository.List()
                .Where(t => t.Durum == "Talepte") // "Beklemede" durumunda olanları filtrele
                .Select(t => new SelectListItem
                {
                    Value = t.YardimTalebiId.ToString(),
                    Text = $"{t.Aciklama} - {t.Adres}"
                }).ToList();

            ViewBag.HelpRequests = yardimTalepleri;

            return View(model);
        }

        [HttpGet]
        public JsonResult GetOrganizationsByAddress(string address)
        {
            var organizations = _kurumsalKullaniciRepository.List()
                .Where(k => k.Kullanici.Adres == address)
                .Select(k => new
                {
                    Id = k.KullaniciId,
                    Name = k.KurumAdi
                }).ToList();

            return Json(organizations, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(YardimEt model)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Login", "Acc");
            }
            var yardim = new YardimEt
            {
                YardimTalebiId = model.YardimTalebi.YardimTalebiId,
                YardimEdenKullaniciId = (int)Session["KullaniciId"],
                KurumId = model.KurumsalKullanici.KullaniciId,
                OnayDurumu = "Beklemede",
                OnayTarihi = null,
                TamamlanmaTarihi = null,
            };
            _yardimEtRepository.Insert(yardim);

            // YardimTalebi durumunu güncelle
            var yardimTalebi = _yardimTalebiRepository.Find(y => y.YardimTalebiId == model.YardimTalebi.YardimTalebiId);
            if (yardimTalebi != null)
            {
                yardimTalebi.Durum = "Beklemede";
                _yardimTalebiRepository.Update(yardimTalebi);
            }

            return RedirectToAction("YardimEt");
        }
    }
}
