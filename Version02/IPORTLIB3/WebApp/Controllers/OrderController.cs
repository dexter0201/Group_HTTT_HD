using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class OrderController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Order.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.SupplierId = new SelectList(AppProvider.Supplier.Gets(), "SupplierId", "SupplierName");
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Order order)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Order.Insert(order);
				return RedirectToAction("Index");
			}
			ViewBag.SupplierId = new SelectList(AppProvider.Supplier.Gets(), "SupplierId", "SupplierName");
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View(order);
		}

		public ActionResult Edit(int id = 0)
		{
			Order order = AppProvider.Order.Get(id);
			ViewBag.SupplierId = new SelectList(AppProvider.Supplier.Gets(), "SupplierId", "SupplierName", order.SupplierId);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", order.StatusId);

			return View(order);
		}

		[HttpPost]
		public ActionResult Edit(Order order)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Order.Update(order);
				return RedirectToAction("Index");
			}
			ViewBag.SupplierId = new SelectList(AppProvider.Supplier.Gets(), "SupplierId", "SupplierName", order.SupplierId);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", order.StatusId);

			return View(order);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Order.Delete(id);
			return RedirectToAction("Index");
		}
	}
}