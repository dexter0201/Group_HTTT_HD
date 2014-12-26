using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class DepartmentController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Department.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Department department)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Department.Insert(department);
				return RedirectToAction("Index");
			}

			return View(department);
		}

		public ActionResult Edit(int id = 0)
		{
			Department department = AppProvider.Department.Get(id);

			return View(department);
		}

		[HttpPost]
		public ActionResult Edit(Department department)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Department.Update(department);
				return RedirectToAction("Index");
			}

			return View(department);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Department.Delete(id);
			return RedirectToAction("Index");
		}
	}
}