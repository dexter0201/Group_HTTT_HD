using System.Web.Mvc;
using BLL;
using DTO;
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
	}
}