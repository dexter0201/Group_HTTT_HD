using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class StatusController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Status.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Status status)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Status.Insert(status);
				return RedirectToAction("Index");
			}

			return View(status);
		}

		public ActionResult Edit(int id = 0)
		{
			Status status = AppProvider.Status.Get(id);

			return View(status);
		}

		[HttpPost]
		public ActionResult Edit(Status status)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Status.Update(status);
				return RedirectToAction("Index");
			}

			return View(status);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Status.Delete(id);
			return RedirectToAction("Index");
		}
	}
}