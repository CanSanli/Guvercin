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
}
