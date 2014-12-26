using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class LoanController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.Loan.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.UserId = new SelectList(AppProvider.User.Gets(), "UserId", "UserName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(Loan loan)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Loan.Insert(loan);
				return RedirectToAction("Index");
			}
			ViewBag.UserId = new SelectList(AppProvider.User.Gets(), "UserId", "UserName");

			return View(loan);
		}

		public ActionResult Edit(int id = 0)
		{
			Loan loan = AppProvider.Loan.Get(id);
			ViewBag.UserId = new SelectList(AppProvider.User.Gets(), "UserId", "UserName", loan.UserId);

			return View(loan);
		}

		[HttpPost]
		public ActionResult Edit(Loan loan)
		{
			if (ModelState.IsValid)
			{
				AppProvider.Loan.Update(loan);
				return RedirectToAction("Index");
			}
			ViewBag.UserId = new SelectList(AppProvider.User.Gets(), "UserId", "UserName", loan.UserId);

			return View(loan);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.Loan.Delete(id);
			return RedirectToAction("Index");
		}
	}
}