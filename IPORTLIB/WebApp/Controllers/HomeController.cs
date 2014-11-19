using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        BookProvider provider = new BookProvider();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ResultSearch()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }

    }
}
