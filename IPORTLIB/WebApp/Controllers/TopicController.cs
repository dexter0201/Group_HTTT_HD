using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class TopicController : Controller
    {
        //
        // GET: /Topic/

        TopicProvider provider = new TopicProvider();
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
