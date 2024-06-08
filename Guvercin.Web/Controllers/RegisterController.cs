using Guvercin.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guvercin.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndividualMemberSave(IndividualMember individualMember)
        {
            Repository<IndividualMember> rpIndividualMember = new Repository<IndividualMember>();
            rpIndividualMember.Insert(individualMember);
            return RedirectToAction("Index");
        }
    }
}