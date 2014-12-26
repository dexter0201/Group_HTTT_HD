using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class PurchaseController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Purchase.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Purchase purchase)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Purchase.Insert(purchase);
				return RedirectToAction("Index");
			}
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View(purchase);
		}

		public ActionResult Edit(int id = 0)
		{
			Purchase purchase = AppProvider.Purchase.Get(id);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", purchase.StatusId);

			return View(purchase);
		}

		[HttpPost]
		public ActionResult Edit(Purchase purchase)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Purchase.Update(purchase);
				return RedirectToAction("Index");
			}
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", purchase.StatusId);

			return View(purchase);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Purchase.Delete(id);
			return RedirectToAction("Index");
		}
	}
}