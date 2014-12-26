using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class CardUserController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.CardUser.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.UserId = new SelectList(AppProvider.User.Gets(), "UserId", "UserName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(CardUser cardUser)
		{
			if (ModelState.IsValid)
			{
				AppProvider.CardUser.Insert(cardUser);
				return RedirectToAction("Index");
			}
			ViewBag.UserId = new SelectList(AppProvider.User.Gets(), "UserId", "UserName");

			return View(cardUser);
		}

		public ActionResult Edit(int id = 0)
		{
			CardUser cardUser = AppProvider.CardUser.Get(id);
			ViewBag.UserId = new SelectList(AppProvider.User.Gets(), "UserId", "UserName", cardUser.UserId);

			return View(cardUser);
		}

		[HttpPost]
		public ActionResult Edit(CardUser cardUser)
		{
			if (ModelState.IsValid)
			{
				AppProvider.CardUser.Update(cardUser);
				return RedirectToAction("Index");
			}
			ViewBag.UserId = new SelectList(AppProvider.User.Gets(), "UserId", "UserName", cardUser.UserId);

			return View(cardUser);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.CardUser.Delete(id);
			return RedirectToAction("Index");
		}
	}
}