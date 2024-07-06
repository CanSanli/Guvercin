using Guvercin.BusinessLayer.Abstract;
using GuvercinApp.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class YardimTalebiController : Controller
{
    private readonly Repository<YardimTalebi> _yardimTalebiRepository = new Repository<YardimTalebi>();
    private readonly Repository<YardimTuru> _yardimTuruRepository = new Repository<YardimTuru>();

    [HttpGet]
    public ActionResult YardimTalepEt()
    {
        if (Session["KullaniciId"] == null)
        {
            return RedirectToAction("Login", "Acc");
        }

        var yardimTurleri = _yardimTuruRepository.List();
        ViewBag.YardimTurleri = new SelectList(yardimTurleri, "YardimTuruId", "YardimTuruAdi");
        return View();
    }

    [HttpPost]
    public ActionResult Save(TalepModel model)
    {
        if (Session["KullaniciId"] == null)
        {
            return RedirectToAction("Login", "Acc");
        }

        if (model.Enlem == 0 || model.Boylam == 0)
        {
            var yardimTurler = _yardimTuruRepository.List();
            ViewBag.YardimTurleri = new SelectList(yardimTurler, "YardimTuruId", "YardimTuruAdi");
            ModelState.AddModelError("", "Geçerli bir adres seçiniz.");
            return View("YardimTalepEt");
        }

        var talep = new YardimTalebi
        {
            KullaniciId = (int)Session["KullaniciId"],
            YardimTuruId = model.YardimTalebi.YardimTuruId,
            Adres = model.YardimTalebi.Adres,
            Aciklama = model.YardimTalebi.Aciklama,
            Enlem = model.Enlem,
            Boylam = model.Boylam,
            Tarih = DateTime.Now,
            Durum = "Talepte"
        };

        _yardimTalebiRepository.Insert(talep);

        var yardimTurleri = _yardimTuruRepository.List();
        ViewBag.YardimTurleri = new SelectList(yardimTurleri, "YardimTuruId", "YardimTuruAdi");
        return View("YardimTalepEt");
    }
}