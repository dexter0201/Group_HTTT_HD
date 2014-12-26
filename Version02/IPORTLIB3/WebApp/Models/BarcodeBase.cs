using System.Web;
using OnBarcode.Barcode;

namespace WebApp.Models
{
    public class BarcodeBase
    {
        public string Gen(string key)
        {
            Linear barcode = new Linear();
            barcode.Type = BarcodeType.CODE128;
            string path = HttpContext.Current.Server.MapPath("/Upload/");
            barcode.Data = key;
            barcode.drawBarcode(string.Format("{0}{1}.png", path, key));
            return path;
        }
    }
}