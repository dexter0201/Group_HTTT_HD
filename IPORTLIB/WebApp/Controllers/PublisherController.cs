using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class PublisherController : Controller
    {
        //
        // GET: /Publisher/
        PublisherProvider provider = new PublisherProvider();
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
