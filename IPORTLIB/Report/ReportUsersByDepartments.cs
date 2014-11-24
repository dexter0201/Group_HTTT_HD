using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using DAL;

namespace Report
{
    public class ReportUsersByDepartments : BaseReport
    {
        protected override IEnumerable<ReportDataSource> GetReportDataSources(object obj)
        {
            DepartmentProvider provider = new DepartmentProvider();
            return new List<ReportDataSource>
            {
                new ReportDataSource{ Name = "ReportUsersDepartments", Value = provider.ReportUsersDepartments()}
            };
        }
        protected override string GetLocalReportPath()
        {
            return GetPath("/Report/ReportUsersDepartments.rdlc");
        }
        protected override IEnumerable<ReportParameter> SetParameters()
        {
            return new List<ReportParameter>
            {
                new ReportParameter("title", "Đại học khoa học tự nhiên")
            };
        }
    }
}
