using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class PublicationTypeController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.PublicationType.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(PublicationType publicationType)
		{
			if (ModelState.IsValid)
			{
				AppProvider.PublicationType.Insert(publicationType);
				return RedirectToAction("Index");
			}

			return View(publicationType);
		}

		public ActionResult Edit(int id = 0)
		{
			PublicationType publicationType = AppProvider.PublicationType.Get(id);

			return View(publicationType);
		}

		[HttpPost]
		public ActionResult Edit(PublicationType publicationType)
		{
			if (ModelState.IsValid)
			{
				AppProvider.PublicationType.Update(publicationType);
				return RedirectToAction("Index");
			}

			return View(publicationType);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.PublicationType.Delete(id);
			return RedirectToAction("Index");
		}
	}
}