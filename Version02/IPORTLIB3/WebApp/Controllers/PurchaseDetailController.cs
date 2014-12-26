using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class PurchaseDetailController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.PurchaseDetail.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.PurchaseId = new SelectList(AppProvider.Purchase.Gets(), "PurchaseId", "PurchaseName");
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(PurchaseDetail purchaseDetail)
		{
			if (ModelState.IsValid)
			{
				AppProvider.PurchaseDetail.Insert(purchaseDetail);
				return RedirectToAction("Index");
			}
			ViewBag.PurchaseId = new SelectList(AppProvider.Purchase.Gets(), "PurchaseId", "PurchaseName");
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View(purchaseDetail);
		}

		public ActionResult Edit(int id = 0)
		{
			PurchaseDetail purchaseDetail = AppProvider.PurchaseDetail.Get(id);
			ViewBag.PurchaseId = new SelectList(AppProvider.Purchase.Gets(), "PurchaseId", "PurchaseName", purchaseDetail.PurchaseId);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", purchaseDetail.StatusId);

			return View(purchaseDetail);
		}

		[HttpPost]
		public ActionResult Edit(PurchaseDetail purchaseDetail)
		{
			if (ModelState.IsValid)
			{
				AppProvider.PurchaseDetail.Update(purchaseDetail);
				return RedirectToAction("Index");
			}
			ViewBag.PurchaseId = new SelectList(AppProvider.Purchase.Gets(), "PurchaseId", "PurchaseName", purchaseDetail.PurchaseId);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", purchaseDetail.StatusId);

			return View(purchaseDetail);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.PurchaseDetail.Delete(id);
			return RedirectToAction("Index");
		}
	}
}