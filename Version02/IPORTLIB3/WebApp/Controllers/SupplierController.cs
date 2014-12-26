using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class SupplierController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Supplier.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(), "ProvinceId", "ProvinceName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Supplier supplier)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Supplier.Insert(supplier);
				return RedirectToAction("Index");
			}
			ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(), "ProvinceId", "ProvinceName");

			return View(supplier);
		}

		public ActionResult Edit(int id = 0)
		{
			Supplier supplier = AppProvider.Supplier.Get(id);
			ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(), "ProvinceId", "ProvinceName", supplier.ProvinceId);

			return View(supplier);
		}

		[HttpPost]
		public ActionResult Edit(Supplier supplier)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Supplier.Update(supplier);
				return RedirectToAction("Index");
			}
			ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(), "ProvinceId", "ProvinceName", supplier.ProvinceId);

			return View(supplier);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Supplier.Delete(id);
			return RedirectToAction("Index");
		}
	}
}