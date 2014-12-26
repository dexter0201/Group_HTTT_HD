using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class CurrencyController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Currency.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Currency currency)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Currency.Insert(currency);
				return RedirectToAction("Index");
			}

			return View(currency);
		}

		public ActionResult Edit(int id = 0)
		{
			Currency currency = AppProvider.Currency.Get(id);

			return View(currency);
		}

		[HttpPost]
		public ActionResult Edit(Currency currency)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Currency.Update(currency);
				return RedirectToAction("Index");
			}

			return View(currency);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Currency.Delete(id);
			return RedirectToAction("Index");
		}
	}
}