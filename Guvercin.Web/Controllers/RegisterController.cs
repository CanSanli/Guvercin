using Guvercin.BusinessLayer.Abstract;
using GuvercinApp.Models;
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

        public ActionResult IndividualMemberSave(RegViewModel model)
        {
            if (model.IndividualMember.HouseholdSize != 0)
            {

            }
            Repository<IndividualMember> rpIndividualMember = new Repository<IndividualMember>();
            rpIndividualMember.Insert(model.IndividualMember);
            return RedirectToAction("Index");
        }



        //public ActionResult IndividualMemberSave(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var context = new DataContext())
        //        {
        //            context.IndividualMembers.Add(model.IndividualMember);
        //            context.SaveChanges();

        //            foreach (var member in model.HouseholdMembers)
        //            {
        //                member.IndividualMemberId = model.IndividualMember.IndividualMemberId;
        //                context.HouseholdMembers.Add(member);
        //            }
        //            context.SaveChanges();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //}
    }
}