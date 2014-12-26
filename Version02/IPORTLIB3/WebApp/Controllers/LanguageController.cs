using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class LanguageController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Language.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Language language)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Language.Insert(language);
				return RedirectToAction("Index");
			}

			return View(language);
		}

		public ActionResult Edit(int id = 0)
		{
			Language language = AppProvider.Language.Get(id);

			return View(language);
		}

		[HttpPost]
		public ActionResult Edit(Language language)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Language.Update(language);
				return RedirectToAction("Index");
			}

			return View(language);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Language.Delete(id);
			return RedirectToAction("Index");
		}
	}
}