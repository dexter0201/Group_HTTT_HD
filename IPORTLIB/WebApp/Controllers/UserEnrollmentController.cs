using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UserEnrollmentController : Controller
    {
        [HttpPost]
        public ActionResult Create(UserEnrollment UE)
        {
            UserEnrollmentProvider UserEnrollmentProvider = new UserEnrollmentProvider();
            UserEnrollmentProvider.Insert(UE);
            return RedirectToAction("Index");
        }

    }
}