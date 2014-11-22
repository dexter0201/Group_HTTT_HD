using System.Configuration;
namespace DAL
{
    public class Config
    {
        public static string ConnectString = ConfigurationManager.ConnectionStrings["IPORTLIB"].ConnectionString;
        public static int pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        public static int defaultSelectedProvince = int.Parse(ConfigurationManager.AppSettings["defaultSelectedProvince"]);
        public static int defaultSelectedGroup = int.Parse(ConfigurationManager.AppSettings["defaultSelectedGroup"]);
        public static int defaultSelectedDepartment = int.Parse(ConfigurationManager.AppSettings["defaultSelectedDepartment"]);
    }
}
