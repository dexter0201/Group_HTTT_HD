using System.Web.Mvc;
using System.Collections.Generic;
using WebApp.Models;
using DAL;

namespace WebApp.Controllers
{
    public class MenuController : Controller
    {
        CategoryProvider provider = new CategoryProvider();
        //
        // GET: /Empty/
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
