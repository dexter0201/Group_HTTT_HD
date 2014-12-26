using System.Collections.Generic;
using System.Web.Mvc;
using BLL;
using DTO;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ReaderController : Controller
    {
        public ActionResult Index(int id = 1)
        {
            UtilityUser model = new UtilityUser { Users = AppProvider.User.Gets(id - 1), Count = AppProvider.User.Page() };
            return View(model);
        }

        public ActionResult Report()
        {
            ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(1), "ProvinceId", "ProvinceName");
            ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public ActionResult Report(UtilityReportUser utility)
        {
            ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(1), "ProvinceId", "ProvinceName");
            ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName");
            return PartialView("Result", new UtilityUser { Users = AppProvider.User.ReportUsers(utility.DepartmentId, utility.ProvinceId) });
        }

        public ActionResult Search(Search search)
        {
            return PartialView(AppProvider.User.Get(search.Keyword));
        }

        public ActionResult SearchByFullName(Search search)
        {
            return PartialView("Result", new UtilityUser { Users = AppProvider.User.GetUsersByFullName(search.Keyword) });
        }

        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName", 1);
            ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(1), "ProvinceId", "ProvinceName", 1);
            ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName", 1);
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            AppProvider.User.Insert(user);
            return RedirectToAction("Index");
        }

        public ActionResult Print()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            User _user = AppProvider.User.Get(id);            
            ViewBag.GroupId = new SelectList(AppProvider.Group.Gets(), "GroupId", "GroupName", _user.GroupId);
            ViewBag.ProvinceId = new SelectList(AppProvider.Province.Gets(1), "ProvinceId", "ProvinceName", _user.ProvinceId);
            ViewBag.DepartmentId = new SelectList(AppProvider.Department.Gets(), "DepartmentId", "DepartmentName", _user.DepartmentId);

            return View(_user);
        }

        [HttpPost]
		public ActionResult Update(User user)
        {
			if (AppProvider.User.Update(user))
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            if (AppProvider.User.Delete(id))
                return RedirectToAction("Index", "Reader");
            return default(ActionResult);
        }

		public ActionResult ImageManage(int pageIndex = 0)
		{
			IEnumerable<Attachment> _listAttachments = AppProvider.Attachment.Gets(pageIndex);
			return View(_listAttachments);
		}
    }
}
