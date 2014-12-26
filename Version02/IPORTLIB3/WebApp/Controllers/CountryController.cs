using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class CountryController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Country.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Country country)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Country.Insert(country);
				return RedirectToAction("Index");
			}

			return View(country);
		}

		public ActionResult Edit(int id = 0)
		{
			Country country = AppProvider.Country.Get(id);

			return View(country);
		}

		[HttpPost]
		public ActionResult Edit(Country country)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Country.Update(country);
				return RedirectToAction("Index");
			}

			return View(country);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Country.Delete(id);
			return RedirectToAction("Index");
		}
	}
}