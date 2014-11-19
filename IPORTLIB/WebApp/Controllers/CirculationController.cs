using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class CirculationController : Controller
    {
        //
        // GET: /Circulation/
        BookProvider provider = new BookProvider();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            return View();
        }
        public ActionResult StatisticBook()
        {
            return View();
        }
        public ActionResult StatisticReader()
        {
            return View();
        }
        public ActionResult Role()
        {
            return View();
        }


    }
}
