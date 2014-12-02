using System.Web.Mvc;
using DTO;
using DAL;
using System.Web;
using System.IO;
using System.Net;

namespace WebApp.Controllers
{
    public class AttachmentController : Controller
    {
        //
        // GET: /Attachment/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Upload(Attachment attachment)
        {
            HttpPostedFileBase file = Request.Files[0];
            attachment.Url = file.FileName;
            file.SaveAs(Server.MapPath("/Uploads/" + file.FileName));
            attachment.AttachmentTypeId = 1;
            AppProvider.AttachmentProvider.Insert(attachment);
            return Json(attachment);
        }

        public JsonResult UploadFromUrl(Attachment attachment)
        {
            string url = Path.GetFileName(attachment.Url);
            WebClient client = new WebClient();
            client.DownloadFile(attachment.Url, Server.MapPath("/Uploads/") + url);
            attachment.AttachmentTypeId = 1;
            attachment.Url = url;
            AppProvider.AttachmentProvider.Insert(attachment);            
            return Json(attachment);
        }

		[HttpPost]
		public int DeleteAttachment(int AttachmentID)
		{
			if (AppProvider.AttachmentProvider.Delete(AttachmentID)) {
				return AttachmentID;
			}

			return -1;
		}
    }
}
