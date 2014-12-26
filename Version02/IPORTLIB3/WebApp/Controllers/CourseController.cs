using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;
using WebApp.Models;
namespace WebApp.Controllers
{
	public class CourseController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Course.Gets());
		}
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Course course)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Course.Insert(course);
				return RedirectToAction("Index");
			}
			return View(course);
		}
        public ActionResult Import(int id = 0, int option = 0)
        {
            Course course = AppProvider.Course.Get(id);
            course.UserEnrolls = AppProvider.UserEnroll.Gets(id);
            return View(course);
        }
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file, int id = 0, int option = 0)
        {
            string path = Upload(file);
            Course course = Insert(id, path);
            return View(course);
        }

        private static Course Insert(int id, string path)
        {
            Course course = AppProvider.Course.Get(id);
            ExcelUserEnroll excelUserEnroll = new ExcelUserEnroll();
            course.UserEnrolls = excelUserEnroll.Gets(path);
            foreach (UserEnroll item in course.UserEnrolls)
            {
                item.CourseId = id;
                item.StatusId = 1;
                item.GroupId = 1;
            }
            AppProvider.UserEnroll.Insert(course.UserEnrolls);
            return course;
        }
        private string Upload(HttpPostedFileBase file)
        {
            string path = Server.MapPath("/Upload/") + file.FileName;
            file.SaveAs(path);
            return path;
        }
		public ActionResult Edit(int id = 0)
		{
			Course course = AppProvider.Course.Get(id);
			return View(course);
		}
		[HttpPost]
		public ActionResult Edit(Course course)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Course.Update(course);
				return RedirectToAction("Index");
			}
			return View(course);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Course.Delete(id);
			return RedirectToAction("Index");
		}
	}
}