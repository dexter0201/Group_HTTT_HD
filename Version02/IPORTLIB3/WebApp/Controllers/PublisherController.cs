using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class PublisherController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Publisher.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Publisher publisher)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Publisher.Insert(publisher);
				return RedirectToAction("Index");
			}

			return View(publisher);
		}

		public ActionResult Edit(int id = 0)
		{
			Publisher publisher = AppProvider.Publisher.Get(id);

			return View(publisher);
		}

		[HttpPost]
		public ActionResult Edit(Publisher publisher)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Publisher.Update(publisher);
				return RedirectToAction("Index");
			}

			return View(publisher);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Publisher.Delete(id);
			return RedirectToAction("Index");
		}
	}
}