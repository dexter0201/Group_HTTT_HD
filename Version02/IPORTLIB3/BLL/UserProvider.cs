using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class UserProvider
	{
		IUserRepository repository;
		internal UserProvider(IUserRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<User> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public User Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(User obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(User obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
        public int Page(object obj = null)
        {
            return repository.Page(obj);
        }
        /* -------- Report Users -----------*/
        public List<ReportUsersLoan> ReportUsersLoan()
        {
            return repository.ReportUsersLoan();
        }

        public IEnumerable<User> GetReportUsersLoanByYear(string year)
        {
            return repository.GetReportUsersLoanByYear(year);
        }
        public IEnumerable<Store> ReportLoansPercent()
        {
            return repository.ReportLoansPercent();
        }

        public List<ReportOutOfDateLoans> GetReportOutOfDateLoans()
        {
            return repository.GetReportOutOfDateLoans();
        }

        /* -------- Theo dõi mượn sách -----------*/
        public IEnumerable<User> GetUsersLoan()
        {
            return repository.GetUsersLoan();

        }
        public IEnumerable<User> GetUsersLoanByUserNo(string userno)
        {
            return repository.GetUsersLoanByUserNo(userno);

        }
        public IEnumerable<User> GetUsersLoanByBookNumber(string book)
        {
            return repository.GetUsersLoanByBookNumber(book);

        }
        public List<ReportOutOfDateLoans> GetDetailLoanByUserid(int id)
        {
            return repository.GetDetailLoanByUserid(id);
        }
        public IEnumerable<User> ReportUsers(int? departmentId, int? provinceId)
        {
            return repository.ReportUsers(departmentId, provinceId);
        }


        public IEnumerable<User> GetUsersByFullName(string p)
        {
            return repository.GetUsersByFullName(p);
        }
    }
}