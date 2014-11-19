using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        BookProvider provider = new BookProvider();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}
