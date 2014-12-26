using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using BLL;
using DTO;
namespace Report
{
    public class ReportUsersByDepartments : BaseReport
    {
        protected override IEnumerable<ReportDataSource> GetReportDataSources(object obj)
        {
            IEnumerable<ReportUsersDepartments> list = AppProvider.Department.ReportUsersDepartments();
            return new List<ReportDataSource>
            {
                new ReportDataSource{ Name = "ReportUsersDepartments", Value = list}
            };
        }
        protected override string GetLocalReportPath()
        {
            return GetPath("/Report/ReportUsersDepartments.rdlc");
        }
        protected override IEnumerable<ReportParameter> SetParameters(object obj = null)
        {
            return new List<ReportParameter>
            {
                new ReportParameter("logo", obj.ToString())
            };
        }
    }
}
