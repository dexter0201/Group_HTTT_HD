using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class UserController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.User.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName");
			ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(), "ProvinceId", "ProvinceName");
			ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName");
			ViewBag.AttachmentId = new SelectList(AppProvider.Attachment.Gets(), "AttachmentId", "AttachmentName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(User user)
		{
			if (ModelState.IsValid)
			{
				AppProvider.User.Insert(user);
				return RedirectToAction("Index");
			}
			ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName");
			ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(), "ProvinceId", "ProvinceName");
			ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName");
			ViewBag.AttachmentId = new SelectList(AppProvider.Attachment.Gets(), "AttachmentId", "AttachmentName");

			return View(user);
		}

		public ActionResult Edit(int id = 0)
		{
			User user = AppProvider.User.Get(id);
			ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName", user.DepartmentId);
			ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(), "ProvinceId", "ProvinceName", user.ProvinceId);
			ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName", user.GroupId);
			ViewBag.AttachmentId = new SelectList(AppProvider.Attachment.Gets(), "AttachmentId", "AttachmentName", user.AttachmentId);

			return View(user);
		}

		[HttpPost]
		public ActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				AppProvider.User.Update(user);
				return RedirectToAction("Index");
			}
			ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName", user.DepartmentId);
			ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(), "ProvinceId", "ProvinceName", user.ProvinceId);
			ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName", user.GroupId);
			ViewBag.AttachmentId = new SelectList(AppProvider.Attachment.Gets(), "AttachmentId", "AttachmentName", user.AttachmentId);

			return View(user);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.User.Delete(id);
			return RedirectToAction("Index");
		}
	}
}