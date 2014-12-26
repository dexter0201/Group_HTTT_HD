using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class TopicController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Topic.Gets());
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Topic topic)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Topic.Insert(topic);
				return RedirectToAction("Index");
			}

			return View(topic);
		}

		public ActionResult Edit(int id = 0)
		{
			Topic topic = AppProvider.Topic.Get(id);

			return View(topic);
		}

		[HttpPost]
		public ActionResult Edit(Topic topic)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Topic.Update(topic);
				return RedirectToAction("Index");
			}

			return View(topic);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Topic.Delete(id);
			return RedirectToAction("Index");
		}
	}
}