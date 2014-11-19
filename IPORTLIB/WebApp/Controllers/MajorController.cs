using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class MajorController : Controller
    {
        //
        // GET: /Major/
        MajorProvider provider = new MajorProvider();
        public ActionResult Index()
        {
            return View();
        }

    }
}
