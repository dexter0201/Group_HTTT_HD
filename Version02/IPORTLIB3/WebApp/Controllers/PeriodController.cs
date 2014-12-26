using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class PeriodController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Period.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.PublicationId = new SelectList(AppProvider.Publication.Gets(), "PublicationId", "PublicationName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Period period)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Period.Insert(period);
				return RedirectToAction("Index");
			}
			ViewBag.PublicationId = new SelectList(AppProvider.Publication.Gets(), "PublicationId", "PublicationName");

			return View(period);
		}

		public ActionResult Edit(int id = 0)
		{
			Period period = AppProvider.Period.Get(id);
			ViewBag.PublicationId = new SelectList(AppProvider.Publication.Gets(), "PublicationId", "PublicationName", period.PublicationId);

			return View(period);
		}

		[HttpPost]
		public ActionResult Edit(Period period)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Period.Update(period);
				return RedirectToAction("Index");
			}
			ViewBag.PublicationId = new SelectList(AppProvider.Publication.Gets(), "PublicationId", "PublicationName", period.PublicationId);

			return View(period);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Period.Delete(id);
			return RedirectToAction("Index");
		}
	}
}