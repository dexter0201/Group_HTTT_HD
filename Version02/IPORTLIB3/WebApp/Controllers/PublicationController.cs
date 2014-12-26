using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class PublicationController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Publication.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.TopicId = new SelectList(AppProvider.Topic.Gets(), "TopicId", "TopicName");
			ViewBag.AuthorId = new SelectList(AppProvider.Author.Gets(), "AuthorId", "AuthorName");
			ViewBag.PublisherId = new SelectList(AppProvider.Publisher.Gets(), "PublisherId", "PublisherName");
			ViewBag.PublicationTypeId = new SelectList(AppProvider.PublicationType.Gets(), "PublicationTypeId", "PublicationTypeName");
			ViewBag.MajorId = new SelectList(AppProvider.Major.Gets(), "MajorId", "MajorName");
			ViewBag.LanguageId = new SelectList(AppProvider.Language.Gets(), "LanguageId", "LanguageName");
			ViewBag.UnitId = new SelectList(AppProvider.Unit.Gets(), "UnitId", "UnitName");
			ViewBag.CurrencyId = new SelectList(AppProvider.Currency.Gets(), "CurrencyId", "CurrencyName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Publication publication)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Publication.Insert(publication);
				return RedirectToAction("Index");
			}
			ViewBag.TopicId = new SelectList(AppProvider.Topic.Gets(), "TopicId", "TopicName");
			ViewBag.AuthorId = new SelectList(AppProvider.Author.Gets(), "AuthorId", "AuthorName");
			ViewBag.PublisherId = new SelectList(AppProvider.Publisher.Gets(), "PublisherId", "PublisherName");
			ViewBag.PublicationTypeId = new SelectList(AppProvider.PublicationType.Gets(), "PublicationTypeId", "PublicationTypeName");
			ViewBag.MajorId = new SelectList(AppProvider.Major.Gets(), "MajorId", "MajorName");
			ViewBag.LanguageId = new SelectList(AppProvider.Language.Gets(), "LanguageId", "LanguageName");
			ViewBag.UnitId = new SelectList(AppProvider.Unit.Gets(), "UnitId", "UnitName");
			ViewBag.CurrencyId = new SelectList(AppProvider.Currency.Gets(), "CurrencyId", "CurrencyName");

			return View(publication);
		}

		public ActionResult Edit(int id = 0)
		{
			Publication publication = AppProvider.Publication.Get(id);
			ViewBag.TopicId = new SelectList(AppProvider.Topic.Gets(), "TopicId", "TopicName", publication.TopicId);
			ViewBag.AuthorId = new SelectList(AppProvider.Author.Gets(), "AuthorId", "AuthorName", publication.AuthorId);
			ViewBag.PublisherId = new SelectList(AppProvider.Publisher.Gets(), "PublisherId", "PublisherName", publication.PublisherId);
			ViewBag.PublicationTypeId = new SelectList(AppProvider.PublicationType.Gets(), "PublicationTypeId", "PublicationTypeName", publication.PublicationTypeId);
			ViewBag.MajorId = new SelectList(AppProvider.Major.Gets(), "MajorId", "MajorName", publication.MajorId);
			ViewBag.LanguageId = new SelectList(AppProvider.Language.Gets(), "LanguageId", "LanguageName", publication.LanguageId);
			ViewBag.UnitId = new SelectList(AppProvider.Unit.Gets(), "UnitId", "UnitName", publication.UnitId);
			ViewBag.CurrencyId = new SelectList(AppProvider.Currency.Gets(), "CurrencyId", "CurrencyName", publication.CurrencyId);

			return View(publication);
		}

		[HttpPost]
		public ActionResult Edit(Publication publication)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Publication.Update(publication);
				return RedirectToAction("Index");
			}
			ViewBag.TopicId = new SelectList(AppProvider.Topic.Gets(), "TopicId", "TopicName", publication.TopicId);
			ViewBag.AuthorId = new SelectList(AppProvider.Author.Gets(), "AuthorId", "AuthorName", publication.AuthorId);
			ViewBag.PublisherId = new SelectList(AppProvider.Publisher.Gets(), "PublisherId", "PublisherName", publication.PublisherId);
			ViewBag.PublicationTypeId = new SelectList(AppProvider.PublicationType.Gets(), "PublicationTypeId", "PublicationTypeName", publication.PublicationTypeId);
			ViewBag.MajorId = new SelectList(AppProvider.Major.Gets(), "MajorId", "MajorName", publication.MajorId);
			ViewBag.LanguageId = new SelectList(AppProvider.Language.Gets(), "LanguageId", "LanguageName", publication.LanguageId);
			ViewBag.UnitId = new SelectList(AppProvider.Unit.Gets(), "UnitId", "UnitName", publication.UnitId);
			ViewBag.CurrencyId = new SelectList(AppProvider.Currency.Gets(), "CurrencyId", "CurrencyName", publication.CurrencyId);

			return View(publication);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Publication.Delete(id);
			return RedirectToAction("Index");
		}
	}
}