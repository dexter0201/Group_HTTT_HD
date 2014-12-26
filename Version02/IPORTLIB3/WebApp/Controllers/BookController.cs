using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class BookController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Book.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.PublicationId = new SelectList(AppProvider.Publication.Gets(), "PublicationId", "PublicationName");
			ViewBag.StoreId = new SelectList(AppProvider.Store.Gets(), "StoreId", "StoreName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Book book)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Book.Insert(book);
				return RedirectToAction("Index");
			}
			ViewBag.PublicationId = new SelectList(AppProvider.Publication.Gets(), "PublicationId", "PublicationName");
			ViewBag.StoreId = new SelectList(AppProvider.Store.Gets(), "StoreId", "StoreName");

			return View(book);
		}

		public ActionResult Edit(int id = 0)
		{
			Book book = AppProvider.Book.Get(id);
			ViewBag.PublicationId = new SelectList(AppProvider.Publication.Gets(), "PublicationId", "PublicationName", book.PublicationId);
			ViewBag.StoreId = new SelectList(AppProvider.Store.Gets(), "StoreId", "StoreName", book.StoreId);

			return View(book);
		}

		[HttpPost]
		public ActionResult Edit(Book book)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Book.Update(book);
				return RedirectToAction("Index");
			}
			ViewBag.PublicationId = new SelectList(AppProvider.Publication.Gets(), "PublicationId", "PublicationName", book.PublicationId);
			ViewBag.StoreId = new SelectList(AppProvider.Store.Gets(), "StoreId", "StoreName", book.StoreId);

			return View(book);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Book.Delete(id);
			return RedirectToAction("Index");
		}
	}
}