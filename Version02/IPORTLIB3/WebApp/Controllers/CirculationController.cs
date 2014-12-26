using System.Web.Mvc;
using DTO;
using System.Collections.Generic;
using BLL;
using WebApp.Models;
using Report;
using System;

namespace WebApp.Controllers
{
    public class CirculationController : Controller
    {
        //
        // GET: /Circulation/
       
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

            List<ReportUsersDepartments> model = AppProvider.Department.ReportUsersDepartments();

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
            string path = new Uri( Server.MapPath("/Images/") + "logo.jpg").AbsoluteUri;
            return File(report.Render(null, path), report.MineType);
        }

        public JsonResult ReportUsersLoanJSON()
        {

            List<ReportUsersLoan> model = AppProvider.User.ReportUsersLoan();

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
            return File(report.Render(year, new Uri(Server.MapPath("/Images/") + "logo.jpg").AbsoluteUri), report.MineType);

        }
        public JsonResult ReportLoansPercentJSON()
        {

            IEnumerable<Store> model = AppProvider.User.ReportLoansPercent();
            var returnObject = new List<object>();
            foreach (Store item in model)
            {
                returnObject.Add(new object[] { item.StoreName, item.LoanPercent });
            }


            return Json(returnObject.ToArray(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetReportOutOfDateLoans(string id)
        {
            BaseReport report = new ReportUsersLoanOutOfDate();
            report.FormatReport = (ReportUsersLoanOutOfDate.Format)int.Parse(id);
            return File(report.Render(null, new Uri(Server.MapPath("/Images/") + "logo.jpg").AbsoluteUri), report.MineType);

        }
        public ActionResult ReportOutOfDateLoans()
        {
            List<ReportOutOfDateLoans> model = AppProvider.User.GetReportOutOfDateLoans();
            return View(model);
        }
        public ActionResult LoanMonitoring()
        {
           IEnumerable<User> model = AppProvider.User.GetUsersLoan();
            return View(model);
        }
        public ActionResult DetailLoan(int id)
        {
            IEnumerable<ReportOutOfDateLoans> model = AppProvider.User.GetDetailLoanByUserid(id);
            return View(model);
        }
        public ActionResult SearchUserLoanByNo(Search search)
        {
            IEnumerable<User> model = null;
            
            if(search.choose == "no")
                 model = AppProvider.User.GetUsersLoanByUserNo(search.Keyword);
            else
            {
                if(search.choose == "book")
                {
                    model = AppProvider.User.GetUsersLoanByBookNumber(search.Keyword);
                }
            }
            return PartialView("LoanMonitoring", model);
        }
    }
}
