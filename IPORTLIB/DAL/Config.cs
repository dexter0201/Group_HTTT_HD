using System.Configuration;
namespace DAL
{
    class Config
    {
        public static string ConnectString = ConfigurationManager.ConnectionStrings["IPORTLIB"].ConnectionString;
        public static int pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
    }
}
