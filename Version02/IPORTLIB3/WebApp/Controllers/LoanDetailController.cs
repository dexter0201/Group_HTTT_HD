using System.Web.Mvc;
using BLL;
using DTO;
namespace WebApp.Controllers
{
	public class LoanDetailController : Controller
	{
		public ActionResult Index()
		{
			return View(AppProvider.LoanDetail.Gets());
		}
		public ActionResult Create()
		{
			ViewBag.LoanId = new SelectList(AppProvider.Loan.Gets(), "LoanId", "LoanName");
			ViewBag.BookId = new SelectList(AppProvider.Book.Gets(), "BookId", "BookName");

			return View();
		}

		[HttpPost]
		public ActionResult Create(LoanDetail loanDetail)
		{
			if (ModelState.IsValid)
			{
				AppProvider.LoanDetail.Insert(loanDetail);
				return RedirectToAction("Index");
			}
			ViewBag.LoanId = new SelectList(AppProvider.Loan.Gets(), "LoanId", "LoanName");
			ViewBag.BookId = new SelectList(AppProvider.Book.Gets(), "BookId", "BookName");

			return View(loanDetail);
		}

		public ActionResult Edit(int id = 0)
		{
			LoanDetail loanDetail = AppProvider.LoanDetail.Get(id);
			ViewBag.LoanId = new SelectList(AppProvider.Loan.Gets(), "LoanId", "LoanName", loanDetail.LoanId);
			ViewBag.BookId = new SelectList(AppProvider.Book.Gets(), "BookId", "BookName", loanDetail.BookId);

			return View(loanDetail);
		}

		[HttpPost]
		public ActionResult Edit(LoanDetail loanDetail)
		{
			if (ModelState.IsValid)
			{
				AppProvider.LoanDetail.Update(loanDetail);
				return RedirectToAction("Index");
			}
			ViewBag.LoanId = new SelectList(AppProvider.Loan.Gets(), "LoanId", "LoanName", loanDetail.LoanId);
			ViewBag.BookId = new SelectList(AppProvider.Book.Gets(), "BookId", "BookName", loanDetail.BookId);

			return View(loanDetail);
		}
		public ActionResult Delete(int id = 0)
		{
			AppProvider.LoanDetail.Delete(id);
			return RedirectToAction("Index");
		}
	}
}