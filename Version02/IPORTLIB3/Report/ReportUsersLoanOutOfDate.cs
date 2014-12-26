using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using BLL;

namespace Report
{
    public class ReportUsersLoanOutOfDate : BaseReport
    {
        protected override IEnumerable<ReportDataSource> GetReportDataSources(object obj)
        {
            
            return new List<ReportDataSource>
            {
                new ReportDataSource{ Name = "ReportOutOfDateLoans", Value = AppProvider.User.GetReportOutOfDateLoans()}
            };
        }
        protected override string GetLocalReportPath()
        {
            return GetPath("/Report/ReportOutOfDateLoans.rdlc");
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
