using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class ProvinceController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Province.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.CountryId = new SelectList(AppProvider.Country.Gets(), "CountryId", "CountryName");
			return View();
		}

		[HttpPost]
		public ActionResult Create(Province province)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Province.Insert(province);
				return RedirectToAction("Index");
			}
			ViewBag.CountryId = new SelectList(AppProvider.Country.Gets(), "CountryId", "CountryName");

			return View(province);
		}

		public ActionResult Edit(int id = 0)
		{
			Province province = AppProvider.Province.Get(id);
			ViewBag.CountryId = new SelectList(AppProvider.Country.Gets(), "CountryId", "CountryName", province.CountryId);

			return View(province);
		}

		[HttpPost]
		public ActionResult Edit(Province province)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Province.Update(province);
				return RedirectToAction("Index");
			}
			ViewBag.CountryId = new SelectList(AppProvider.Country.Gets(), "CountryId", "CountryName", province.CountryId);

			return View(province);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Province.Delete(id);
			return RedirectToAction("Index");
		}
	}
}