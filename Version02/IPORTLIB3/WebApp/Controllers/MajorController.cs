using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class MajorController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Major.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Major major)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Major.Insert(major);
				return RedirectToAction("Index");
			}

			return View(major);
		}

		public ActionResult Edit(int id = 0)
		{
			Major major = AppProvider.Major.Get(id);

			return View(major);
		}

		[HttpPost]
		public ActionResult Edit(Major major)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Major.Update(major);
				return RedirectToAction("Index");
			}

			return View(major);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Major.Delete(id);
			return RedirectToAction("Index");
		}
	}
}