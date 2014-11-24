using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using DAL;

namespace Report
{
    public class ReportUsersLoanByYear : BaseReport
    {
        protected override IEnumerable<ReportDataSource> GetReportDataSources(object obj)
        {
            UserProvider provider = new UserProvider();
            return new List<ReportDataSource>
            {
                new ReportDataSource{ Name = "ReportUsersLoan", Value = provider.GetReportUsersLoanByYear((string)obj)}
            };
        }
        protected override string GetLocalReportPath()
        {
            return GetPath("/Report/ReportUsersLoan.rdlc");
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
