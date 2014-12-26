using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using BLL;

namespace Report
{
    public class ReportUsersLoanByYear : BaseReport
    {
        protected override IEnumerable<ReportDataSource> GetReportDataSources(object obj)
        {
            
            return new List<ReportDataSource>
            {
                new ReportDataSource{ Name = "ReportUsersLoan", Value = AppProvider.User.GetReportUsersLoanByYear((string)obj)}
            };
        }
        protected override string GetLocalReportPath()
        {
            return GetPath("/Report/ReportUsersLoan.rdlc");
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
