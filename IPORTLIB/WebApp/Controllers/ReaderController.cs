using System.Web.Mvc;
using DAL;
using WebApp.Utility;
using DTO;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class ReaderController : Controller
    {
        public ActionResult Index(int id = 1)
        {
            UtilityUser model = new UtilityUser { Users = AppProvider.UserProvider.Gets(id - 1), Count = AppProvider.UserProvider.Page() };
            return View(model);
        }

        public ActionResult Report()
        {
            ViewBag.ProvinceId = new SelectList(AppProvider.ProvinceProvider.Gets(1), "ProvinceId", "ProvinceName");
            ViewBag.DepartmentId = new SelectList(AppProvider.DeparmentProvider.Gets(), "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public ActionResult Report(UtilityReportUser utility)
        {
            ViewBag.ProvinceId = new SelectList(AppProvider.ProvinceProvider.Gets(1), "ProvinceId", "ProvinceName");
            ViewBag.DepartmentId = new SelectList(AppProvider.DeparmentProvider.Gets(), "DepartmentId", "DepartmentName");
            return PartialView("Result", new UtilityUser { Users = AppProvider.UserProvider.ReportUsers(utility.DepartmentId, utility.ProvinceId) });
        }

        public ActionResult Search(Search search)
        {
            return PartialView(AppProvider.UserProvider.Get(search.Keyword));
        }

        public ActionResult SearchByFullName(Search search)
        {
            return PartialView("Result", new UtilityUser { Users = AppProvider.UserProvider.GetUsersByFullName(search.Keyword) });
        }

        public ActionResult Create()
        {
            
            GroupProvider groupProvider = new GroupProvider();
            ViewBag.GroupId = new SelectList(AppProvider.GroupProvider.Gets(), "GroupId", "GroupName");
            ViewBag.ProvinceId = new SelectList(AppProvider.ProvinceProvider.Gets(1), "ProvinceId", "ProvinceName");
            ViewBag.DepartmentId = new SelectList(AppProvider.DeparmentProvider.Gets(), "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            AppProvider.UserProvider.Insert(user);
            return RedirectToAction("Index");
        }

        public ActionResult Print()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            User _user = AppProvider.UserProvider.Get(id);

            GroupProvider groupProvider = new GroupProvider();
            ViewBag.GroupId = new SelectList(AppProvider.GroupProvider.Gets(), "GroupId", "GroupName", _user.GroupId);
            ViewBag.ProvinceId = new SelectList(AppProvider.ProvinceProvider.Gets(1), "ProvinceId", "ProvinceName", _user.ProvinceId);
            ViewBag.DepartmentId = new SelectList(AppProvider.DeparmentProvider.Gets(), "DepartmentId", "DepartmentName", _user.DepartmentId);

            return View(_user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            AppProvider.UserProvider.Update(user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (AppProvider.UserProvider.Delete(id))
                return RedirectToAction("Index", "Reader");
            return default(ActionResult);
        }
    }
}
