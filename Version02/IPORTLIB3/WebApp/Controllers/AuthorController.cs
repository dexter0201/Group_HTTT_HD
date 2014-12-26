using System.Web.Mvc;
using BLL;
using DTO;
using WebApp.Models;
namespace WebApp.Controllers
{
	public class AuthorController : Controller
	{
		public ActionResult Index(int id = 1)
		{
            Model<Author> model = new Model<Author> { Page = AppProvider.Author.Page(), Objs = AppProvider.Author.Gets(id - 1) };
            return View(model);
		}
		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(Author author)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Author.Insert(author);
				return RedirectToAction("Index");
			}

			return View(author);
		}

		public ActionResult Edit(int id = 0)
		{
			Author author = AppProvider.Author.Get(id);

			return View(author);
		}

		[HttpPost]
		public ActionResult Edit(Author author)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Author.Update(author);
				return RedirectToAction("Index");
			}

			return View(author);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Author.Delete(id);
			return RedirectToAction("Index");
		}
	}
}