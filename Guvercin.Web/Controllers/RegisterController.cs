using System;
using System.Web.Mvc;
using Guvercin.BusinessLayer.Abstract;
using Guvercin.DataAccessLayer;
using GuvercinApp.Models;

public class RegisterController : Controller
{
    private readonly Repository<Kullanici> _kullaniciRepository = new Repository<Kullanici>();
    private readonly Repository<BireyselKullanici> _bireyselKullaniciRepository = new Repository<BireyselKullanici>();
    private readonly Repository<KurumsalKullanici> _kurumsalKullaniciRepository = new Repository<KurumsalKullanici>();

    public ActionResult Index()
    {
        var model = new RegViewModel();
        return View(model);
    }

    [HttpPost]
    public ActionResult Save(RegViewModel model)
    {

            var kullanici = new Kullanici
            {
                KullaniciTipi = model.RegistrationType,
                KullaniciAdi = model.Kullanici.KullaniciAdi,
                Email = model.Kullanici.Email,
                Sifre = model.Kullanici.Sifre,
                Telefon = model.Kullanici.Telefon,
                Adres = model.Kullanici.Adres
            };

            _kullaniciRepository.Insert(kullanici);

            if (model.RegistrationType == "bireysel")
            {
                var bireyselKullanici = new BireyselKullanici
                {
                    KullaniciId = kullanici.KullaniciId,
                    Ad = model.BireyselKullanici.Ad,
                    Soyad = model.BireyselKullanici.Soyad,
                    DogumTarihi = model.BireyselKullanici.DogumTarihi
                };

                _bireyselKullaniciRepository.Insert(bireyselKullanici);
            }
            else if (model.RegistrationType == "kurumsal")
            {
                var kurumsalKullanici = new KurumsalKullanici
                {
                    KullaniciId = kullanici.KullaniciId,
                    KurumAdi = model.KurumsalKullanici.KurumAdi,
                    VergiNo = model.KurumsalKullanici.VergiNo,
                    KurulusTarihi = model.KurumsalKullanici.KurulusTarihi
                };

                _kurumsalKullaniciRepository.Insert(kurumsalKullanici);
            }

            return RedirectToAction("Index","Home");
        

        // ModelState.IsValid false olduğunda buraya düşer, hataları göstermek için tekrar Index view'ını döndürüyoruz.
    }


    public ActionResult Success()
    {
        return View();
    }
}


