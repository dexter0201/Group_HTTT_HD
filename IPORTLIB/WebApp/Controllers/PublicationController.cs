using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PublicationController : Controller
    {
        //
        // GET: /Publication/

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
