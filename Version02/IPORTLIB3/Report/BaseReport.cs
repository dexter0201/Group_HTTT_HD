using System.Collections.Generic;
using System.Xml;
using Microsoft.Reporting.WebForms;
using System.Web;

namespace Report
{
    public abstract class BaseReport
    {
        public enum Format
        {
            PDF = 1,
            Word = 2,
            Excel = 3
        };
        public Format FormatReport { get; set; }
        string mineType;
        public string MineType
        {
            get { return mineType; }
        }
        LocalReport localReport;
        public BaseReport()
        {
            localReport = new LocalReport();
            FormatReport = Format.PDF;
        }
        protected string GetPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
        public byte[] Render(object obj = null, object parameters = null)
        {
            localReport.ReportPath = GetLocalReportPath();
            localReport.EnableExternalImages = true;
            IEnumerable<ReportParameter> param = SetParameters(parameters);
            if (param != null)
                localReport.SetParameters(param);
            IEnumerable<ReportDataSource> ReportDataSources = GetReportDataSources(obj);
            foreach (ReportDataSource item in ReportDataSources)
            {
                localReport.DataSources.Add(item);
            }
            string reportType = FormatReport.ToString();
            string encoding;
            string fileNameExtension;
            string deviceInfo = GetLayout();
            Warning[] warning;
            string[] streams;
            return localReport.Render(reportType, deviceInfo, out mineType, out encoding, out fileNameExtension, out streams, out warning);
        }

        private string GetLayout()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(GetPath("/LayoutReport.xml"));
            string layout = doc.DocumentElement.OuterXml;
            return string.Format(layout, FormatReport);
        }
        protected abstract IEnumerable<ReportDataSource> GetReportDataSources(object obj = null);
        protected abstract string GetLocalReportPath();
        protected abstract IEnumerable<ReportParameter> SetParameters(object parameters = null);
    }
}
