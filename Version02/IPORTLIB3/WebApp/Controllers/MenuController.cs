using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MenuController : Controller
    {
        [ChildActionOnly]
        public ActionResult Index()
        {
            List<Item> menu = MenuProvider.GetMenu();
            return PartialView(menu);
        }
        [ChildActionOnly]
        public ActionResult Breadcrumb(string id)
        {
            ViewBag.Title = id;
            string module = MenuProvider.GetModule();
            return PartialView("Breadcrumb", module);
        }

    }
}
