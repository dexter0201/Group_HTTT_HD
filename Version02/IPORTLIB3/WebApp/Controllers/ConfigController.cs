using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class ConfigController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Config.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Config config)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Config.Insert(config);
				return RedirectToAction("Index");
			}
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View(config);
		}

		public ActionResult Edit(int id = 0)
		{
			Config config = AppProvider.Config.Get(id);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", config.StatusId);

			return View(config);
		}

		[HttpPost]
		public ActionResult Edit(Config config)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Config.Update(config);
				return RedirectToAction("Index");
			}
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", config.StatusId);

			return View(config);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Config.Delete(id);
			return RedirectToAction("Index");
		}
	}
}