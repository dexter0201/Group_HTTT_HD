using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class UserEnrollController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.UserEnroll.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.CourseId = new SelectList(AppProvider.Course.Gets(), "CourseId", "CourseName");
			ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName");
			ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName");
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");
			return View();
		}

		[HttpPost]
		public ActionResult Create(UserEnroll userEnroll)
		{
			if (ModelState.IsValid)
			{
				AppProvider.UserEnroll.Insert(userEnroll);
				return RedirectToAction("Index");
			}
			ViewBag.CourseId = new SelectList(AppProvider.Course.Gets(), "CourseId", "CourseName");
			ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName");
			ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName");
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName");

			return View(userEnroll);
		}

		public ActionResult Edit(int id = 0)
		{
			UserEnroll userEnroll = AppProvider.UserEnroll.Get(id);
			ViewBag.CourseId = new SelectList(AppProvider.Course.Gets(), "CourseId", "CourseName", userEnroll.CourseId);
			ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName", userEnroll.GroupId);
			ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName", userEnroll.DepartmentId);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", userEnroll.StatusId);

			return View(userEnroll);
		}

		[HttpPost]
		public ActionResult Edit(UserEnroll userEnroll)
		{
			if (ModelState.IsValid)
			{
				AppProvider.UserEnroll.Update(userEnroll);
				return RedirectToAction("Index");
			}
			ViewBag.CourseId = new SelectList(AppProvider.Course.Gets(), "CourseId", "CourseName", userEnroll.CourseId);
			ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName", userEnroll.GroupId);
			ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName", userEnroll.DepartmentId);
			ViewBag.StatusId = new SelectList(AppProvider.Status.Gets(), "StatusId", "StatusName", userEnroll.StatusId);

			return View(userEnroll);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.UserEnroll.Delete(id);
			return RedirectToAction("Index");
		}
	}
}