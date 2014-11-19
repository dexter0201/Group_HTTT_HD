using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/
        AuthorProvider provider = new AuthorProvider();
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
