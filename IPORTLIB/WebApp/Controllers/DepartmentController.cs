using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        DepartmentProvider provider = new DepartmentProvider();
        public ActionResult Index()
        {
            return View();
        }

    }
}
