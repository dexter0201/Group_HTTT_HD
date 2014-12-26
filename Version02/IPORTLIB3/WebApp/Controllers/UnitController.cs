using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class UnitController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Unit.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Unit unit)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Unit.Insert(unit);
				return RedirectToAction("Index");
			}

			return View(unit);
		}

		public ActionResult Edit(int id = 0)
		{
			Unit unit = AppProvider.Unit.Get(id);

			return View(unit);
		}

		[HttpPost]
		public ActionResult Edit(Unit unit)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Unit.Update(unit);
				return RedirectToAction("Index");
			}

			return View(unit);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Unit.Delete(id);
			return RedirectToAction("Index");
		}
	}
}