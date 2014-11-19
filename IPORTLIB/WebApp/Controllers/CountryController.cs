using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Country/
        CountryProvider provider = new CountryProvider();
        public ActionResult Index()
        {
            return View();
        }

    }
}
