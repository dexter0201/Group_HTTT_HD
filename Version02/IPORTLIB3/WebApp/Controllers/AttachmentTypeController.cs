using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class AttachmentTypeController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.AttachmentType.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(AttachmentType attachmentType)
		{
			if (ModelState.IsValid)
			{
				AppProvider.AttachmentType.Insert(attachmentType);
				return RedirectToAction("Index");
			}

			return View(attachmentType);
		}

		public ActionResult Edit(int id = 0)
		{
			AttachmentType attachmentType = AppProvider.AttachmentType.Get(id);

			return View(attachmentType);
		}

		[HttpPost]
		public ActionResult Edit(AttachmentType attachmentType)
		{
			if (ModelState.IsValid)
			{
				AppProvider.AttachmentType.Update(attachmentType);
				return RedirectToAction("Index");
			}

			return View(attachmentType);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.AttachmentType.Delete(id);
			return RedirectToAction("Index");
		}
	}
}