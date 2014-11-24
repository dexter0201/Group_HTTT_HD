using System.Collections.Generic;
namespace DTO
{
    public class Loan
    {
        public int LoanId { get; set; }
        public virtual List<LoanItem> LoanItems { get; set; }
        public int UserId { get; set; }
        public string UserNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
    }
}
