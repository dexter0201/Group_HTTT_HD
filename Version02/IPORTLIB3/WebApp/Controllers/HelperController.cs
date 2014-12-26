using OnBarcode.Barcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HelperController : Controller
    {
        //
        // GET: /Helper/

        public string GenerateBarcode(string data)
        {
			Linear barcode = new Linear();
			barcode.Type = BarcodeType.CODE128;
			string path = Server.MapPath("/Uploads/UsersBarcode/");
			barcode.Data = data;
			barcode.drawBarcode(string.Format("{0}{1}.png", path, data));
			return (data + ".png");
        }

    }
}
