using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class StoreController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Store.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Store store)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Store.Insert(store);
				return RedirectToAction("Index");
			}

			return View(store);
		}

		public ActionResult Edit(int id = 0)
		{
			Store store = AppProvider.Store.Get(id);

			return View(store);
		}

		[HttpPost]
		public ActionResult Edit(Store store)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Store.Update(store);
				return RedirectToAction("Index");
			}

			return View(store);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Store.Delete(id);
			return RedirectToAction("Index");
		}
	}
}