using System.Configuration;
namespace IDAL
{
    public static class Setting
    {
        public static string ConnString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public static string ConnectExcel = ConfigurationManager.ConnectionStrings["dbexcel"].ConnectionString;
        public static int PageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        public static string Namespace = ConfigurationManager.AppSettings["namespace"];
        public static string ClassName(string keyword)
        {
            return ConfigurationManager.AppSettings[keyword];
        }
        public static string From = ConfigurationManager.AppSettings["from"];
        public static bool EnableCaching = bool.Parse(ConfigurationManager.AppSettings["enableCaching"]);
        public static int CacheDuration = int.Parse(ConfigurationManager.AppSettings["cacheDuration"]);
    }
}