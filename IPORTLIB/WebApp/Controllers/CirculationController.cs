using System.Web.Mvc;
using DAL;
using DTO;
using Report;
using System.Data;
using System.Collections.Generic;
using WebApp.Utility;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class CirculationController : Controller
    {
        //
        // GET: /Circulation/
        BookProvider provider = new BookProvider();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            return View();
        }
        public ActionResult StatisticBook()
        {
            return View();
        }
        public ActionResult StatisticReader()
        {
            return View();
        }

        public ActionResult Role()
        {
            return View();
        }
        public JsonResult ReportUsersDepartmentsJSON()
        {

            List<ReportUsersDepartments> model = AppProvider.DeparmentProvider.ReportUsersDepartments();

            List<int> value = new List<int>();
            List<string> name = new List<string>();
            foreach (ReportUsersDepartments item in model)
            {
                value.Add(item.CountUsers);
                name.Add(item.DepartmentName);
            }
            object obj = new { value, name };

            return Json(obj, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetReportUsersDepartment(string id)
        {
            BaseReport report = new ReportUsersByDepartments();
            report.FormatReport = (ReportUsersByDepartments.Format)int.Parse(id);
            return File(report.Render(), report.MineType);
        }

        public JsonResult ReportUsersLoanJSON()
        {

            List<ReportUsersLoan> model = AppProvider.UserProvider.ReportUsersLoan();

            List<int> value = new List<int>();
            List<string> name = new List<string>();
            foreach (ReportUsersLoan item in model)
            {
                value.Add(item.Count);
                name.Add(item.Year);
            }
            object obj = new { value, name };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetReportUsersLoanByYear(string year)
        {
            BaseReport report = new ReportUsersLoanByYear();
            report.FormatReport = (ReportUsersLoanByYear.Format)1;
            return File(report.Render(year), report.MineType);

        }
        public JsonResult ReportLoansPercentJSON()
        {

            List<Stores> model = AppProvider.UserProvider.ReportLoansPercent();
            var returnObject = new List<object>();
            foreach (Stores item in model)
            {
                returnObject.Add(new object[] { item.StoreName, item.LoanPercent });
            }


            return Json(returnObject.ToArray(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetReportOutOfDateLoans(string id)
        {
            BaseReport report = new ReportUsersLoanOutOfDate();
            report.FormatReport = (ReportUsersLoanOutOfDate.Format)int.Parse(id);
            return File(report.Render(), report.MineType);

        }
        public ActionResult ReportOutOfDateLoans()
        {
            List<ReportOutOfDateLoans> model = AppProvider.UserProvider.GetReportOutOfDateLoans();

            return View(model);
        }
        public ActionResult LoanMonitoring()
        {
            List<User> model = AppProvider.UserProvider.GetUsersLoan();
            return View(model);
        }
        public ActionResult DetailLoan(int id)
        {
            List<ReportOutOfDateLoans> model = AppProvider.UserProvider.GetDetailLoanByUserid(id);
            return View(model);
        }
        public ActionResult SearchUserLoanByNo(Search search)
        {
            List<User> model = AppProvider.UserProvider.GetUsersLoanByUserNo(search.Keyword);
            return PartialView("LoanMonitoring", model);
        }
    }
}
