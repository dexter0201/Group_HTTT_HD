using System.Web.Mvc;
using BLL;
using DTO;
using System.Web;
using System.IO;
using System.Net;
namespace WebApp.Controllers
{
	public class AttachmentController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Attachment.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.AttachmentTypeId = new SelectList(AppProvider.AttachmentType.Gets(), "AttachmentTypeId", "AttachmentTypeName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Attachment attachment)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Attachment.Insert(attachment);
				return RedirectToAction("Index");
			}
			ViewBag.AttachmentTypeId = new SelectList(AppProvider.AttachmentType.Gets(), "AttachmentTypeId", "AttachmentTypeName");

			return View(attachment);
		}

		public ActionResult Edit(int id = 0)
		{
			Attachment attachment = AppProvider.Attachment.Get(id);
			ViewBag.AttachmentTypeId = new SelectList(AppProvider.AttachmentType.Gets(), "AttachmentTypeId", "AttachmentTypeName", attachment.AttachmentTypeId);

			return View(attachment);
		}

		[HttpPost]
		public ActionResult Edit(Attachment attachment)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Attachment.Update(attachment);
				return RedirectToAction("Index");
			}
			ViewBag.AttachmentTypeId = new SelectList(AppProvider.AttachmentType.Gets(), "AttachmentTypeId", "AttachmentTypeName", attachment.AttachmentTypeId);

			return View(attachment);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Attachment.Delete(id);
			return RedirectToAction("Index");
		}

        [HttpPost]
		public JsonResult Upload(Attachment attachment)
		{
			HttpPostedFileBase file = Request.Files[0];
			attachment.Url = file.FileName;
			file.SaveAs(Server.MapPath("/Uploads/" + file.FileName));
			attachment.AttachmentTypeId = 1;
			AppProvider.Attachment.Insert(attachment);
			return Json(attachment);
		}

		public JsonResult UploadFromUrl(Attachment attachment)
		{
			string url = Path.GetFileName(attachment.Url);
			WebClient client = new WebClient();
			client.DownloadFile(attachment.Url, Server.MapPath("/Uploads/") + url);
			attachment.AttachmentTypeId = 1;
			attachment.Url = url;
			AppProvider.Attachment.Insert(attachment);
			return Json(attachment);
		}

		[HttpPost]
		public int DeleteAttachment(int AttachmentID)
		{
			Attachment _curAttach = AppProvider.Attachment.Get(AttachmentID);

			if (AppProvider.Attachment.Delete(AttachmentID))
			{
				System.IO.File.Delete(Server.MapPath("/Uploads/" + _curAttach.Url));
				return AttachmentID;
			}

			return -1;
		}
	}
}