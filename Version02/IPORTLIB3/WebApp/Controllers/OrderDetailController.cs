using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class OrderDetailController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.OrderDetail.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.OrderId = new SelectList(AppProvider.Order.Gets(), "OrderId", "OrderName");
			ViewBag.PurchaseDetailId = new SelectList(AppProvider.PurchaseDetail.Gets(), "PurchaseDetailId", "PurchaseDetailName");
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(OrderDetail orderDetail)
		{
			if (ModelState.IsValid)
			{
				AppProvider.OrderDetail.Insert(orderDetail);
				return RedirectToAction("Index");
			}
			ViewBag.OrderId = new SelectList(AppProvider.Order.Gets(), "OrderId", "OrderName");
			ViewBag.PurchaseDetailId = new SelectList(AppProvider.PurchaseDetail.Gets(), "PurchaseDetailId", "PurchaseDetailName");
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View(orderDetail);
		}

		public ActionResult Edit(int id = 0)
		{
			OrderDetail orderDetail = AppProvider.OrderDetail.Get(id);
			ViewBag.OrderId = new SelectList(AppProvider.Order.Gets(), "OrderId", "OrderName", orderDetail.OrderId);
			ViewBag.PurchaseDetailId = new SelectList(AppProvider.PurchaseDetail.Gets(), "PurchaseDetailId", "PurchaseDetailName", orderDetail.PurchaseDetailId);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", orderDetail.StatusId);

			return View(orderDetail);
		}

		[HttpPost]
		public ActionResult Edit(OrderDetail orderDetail)
		{
			if (ModelState.IsValid)
			{
				AppProvider.OrderDetail.Update(orderDetail);
				return RedirectToAction("Index");
			}
			ViewBag.OrderId = new SelectList(AppProvider.Order.Gets(), "OrderId", "OrderName", orderDetail.OrderId);
			ViewBag.PurchaseDetailId = new SelectList(AppProvider.PurchaseDetail.Gets(), "PurchaseDetailId", "PurchaseDetailName", orderDetail.PurchaseDetailId);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", orderDetail.StatusId);

			return View(orderDetail);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.OrderDetail.Delete(id);
			return RedirectToAction("Index");
		}
	}
}