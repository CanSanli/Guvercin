using System;
using System.Linq;
using System.Web.Mvc;
using Guvercin.DataAccessLayer;
using GuvercinApp.Models;

public class YardimlarimController : Controller
{
    private readonly DataContext _context = new DataContext();
    // YardimTaleplerim sayfası
    public ActionResult YardimTaleplerim()
    {
        if (Session["KullaniciId"] == null)
        {
            return RedirectToAction("Login", "Acc");
        }

        int kullaniciId = (int)Session["KullaniciId"];
        var model = new YardimListViewModel
        {
            YardimTalepler = _context.YardimTalepleri
                                   .Where(y => y.KullaniciId == kullaniciId)
                                   .ToList()
        };
        return View(model);
    }

    // YardimEttiklerim sayfası
    public ActionResult YardimEttiklerim()
    {
        if (Session["KullaniciId"] == null)
        {
            return RedirectToAction("Login", "Acc");
        }

        int kullaniciId = (int)Session["KullaniciId"];
        var model = new YardimListViewModel
        {
            YardimEtler = _context.YardimEts
                                 .Where(ye => ye.YardimEdenKullaniciId == kullaniciId)
                                 .ToList()
        };
        return View(model);
    }
    public ActionResult Islemler()
    {
        if (Session["KullaniciId"] == null)
        {
            return RedirectToAction("Login", "Acc");
        }

        int kurumId = (int)Session["KullaniciId"];

        var gelenTalepler = _context.YardimEts
            .Where(y => y.KurumId == kurumId && y.OnayDurumu == "Beklemede")
            .ToList();

        var onaylananTalepler = _context.YardimEts
            .Where(y => y.KurumId == kurumId && y.OnayDurumu == "Onaylandi")
            .ToList();

        var tamamlananTalepler = _context.YardimEts
            .Where(y => y.KurumId == kurumId && y.OnayDurumu == "Tamamlandi")
            .ToList();

        var tamamlanamayanTalepler = _context.YardimEts
            .Where(y => y.KurumId == kurumId && y.OnayDurumu == "Tamamlanamadi")
            .ToList();

        var reddedilenTalepler = _context.YardimEts
            .Where(y => y.KurumId == kurumId && y.OnayDurumu == "Reddedildi")
            .ToList();

        var butunTalepler = _context.YardimEts.Where(y => y.KurumId == kurumId).ToList();

        var model = new IslemlerViewModel
        {
            GelenTalepler = gelenTalepler,
            OnaylananTalepler = onaylananTalepler,
            TamamlananTalepler = tamamlananTalepler,
            TamamlanamayanTalepler = tamamlanamayanTalepler,
            ReddedilenTalepler = reddedilenTalepler,
            ButunTalepler = butunTalepler
        };

        return View(model);
    }

    [HttpPost]
    public ActionResult Onayla(int id)
    {
        var yardimEt = _context.YardimEts.FirstOrDefault(y => y.YardimEtId == id);
        if (yardimEt != null)
        {
            yardimEt.OnayDurumu = "Onaylandi";
            yardimEt.OnayTarihi = DateTime.Now;

            var yardimTalebi = _context.YardimTalepleri.FirstOrDefault(y => y.YardimTalebiId == yardimEt.YardimTalebiId);
            if (yardimTalebi != null)
            {
                yardimTalebi.Durum = "Onaylandi";
            }

            _context.SaveChanges();
        }

        return RedirectToAction("Islemler");
    }

    [HttpPost]
    public ActionResult Reddet(int id)
    {
        var yardimEt = _context.YardimEts.FirstOrDefault(y => y.YardimEtId == id);
        if (yardimEt != null)
        {
            yardimEt.OnayDurumu = "Reddedildi";

            var yardimTalebi = _context.YardimTalepleri.FirstOrDefault(y => y.YardimTalebiId == yardimEt.YardimTalebiId);
            if (yardimTalebi != null)
            {
                yardimTalebi.Durum = "Reddedildi";
            }

            _context.SaveChanges();
        }

        return RedirectToAction("Islemler");
    }

    [HttpPost]
    public ActionResult Tamamlandi(int id)
    {
        var yardimEt = _context.YardimEts.FirstOrDefault(y => y.YardimEtId == id);
        if (yardimEt != null)
        {
            yardimEt.OnayDurumu = "Tamamlandi";
            yardimEt.TamamlanmaTarihi = DateTime.Now;

            var yardimTalebi = _context.YardimTalepleri.FirstOrDefault(y => y.YardimTalebiId == yardimEt.YardimTalebiId);
            if (yardimTalebi != null)
            {
                yardimTalebi.Durum = "Tamamlandi";
            }

            _context.SaveChanges();
        }

        return RedirectToAction("Islemler");
    }

    [HttpPost]
    public ActionResult Tamamlanamadi(int id)
    {
        var yardimEt = _context.YardimEts.FirstOrDefault(y => y.YardimEtId == id);
        if (yardimEt != null)
        {
            yardimEt.OnayDurumu = "Tamamlanamadi";

            var yardimTalebi = _context.YardimTalepleri.FirstOrDefault(y => y.YardimTalebiId == yardimEt.YardimTalebiId);
            if (yardimTalebi != null)
            {
                yardimTalebi.Durum = "Tamamlanamadi";
            }

            _context.SaveChanges();
        }

        return RedirectToAction("Islemler");
    }
}
