using System;
namespace DTO
{
    public class LoanDetail
    {
		public int LoanDetailId { get; set; }
		public int LoanId { get; set; }
		public int BookId { get; set; }
		public DateTime DateLoan { get; set; }
		public DateTime DatePay { get; set; }

    }
}
