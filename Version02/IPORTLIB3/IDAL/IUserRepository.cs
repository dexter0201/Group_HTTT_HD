using DTO;
using System.Collections.Generic;
namespace IDAL
{
	public interface IUserRepository : IRepository<User>
	{
        /* -------- Report Users -----------*/
        List<ReportUsersLoan> ReportUsersLoan();
        IEnumerable<User> GetReportUsersLoanByYear(string year);
        IEnumerable<Store> ReportLoansPercent();
        List<ReportOutOfDateLoans> GetReportOutOfDateLoans();
        /* -------- Theo dõi mượn sách -----------*/
        IEnumerable<User> GetUsersLoan();
        IEnumerable<User> GetUsersLoanByUserNo(string userno);
        IEnumerable<User> GetUsersLoanByBookNumber(string book);
        List<ReportOutOfDateLoans> GetDetailLoanByUserid(int id);
        IEnumerable<User> ReportUsers(int? departmentId, int? provinceId);
        IEnumerable<User> GetUsersByFullName(string keyword);
        
	}
}
