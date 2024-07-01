using Guvercin.BusinessLayer.Abstract;
using GuvercinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guvercin.Web.Controllers
{

    public class YardımTalebiController : Controller
    {
        private readonly Repository<YardimTalebi> _yardimTalebiRepository = new Repository<YardimTalebi>();
        public ActionResult YardımTalepEt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(TalepModel model)
        {
            var talep = new YardimTalebi
            {
                
            };
            _yardimTalebiRepository.Insert(talep);

            return View();
        }
    }
}