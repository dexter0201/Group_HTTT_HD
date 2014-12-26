using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class GroupController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Group.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Group group)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Group.Insert(group);
				return RedirectToAction("Index");
			}

			return View(group);
		}

		public ActionResult Edit(int id = 0)
		{
			Group group = AppProvider.Group.Get(id);

			return View(group);
		}

		[HttpPost]
		public ActionResult Edit(Group group)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Group.Update(group);
				return RedirectToAction("Index");
			}

			return View(group);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Group.Delete(id);
			return RedirectToAction("Index");
		}
	}
}