using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/
        SupplierProvider provider = new SupplierProvider();
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
