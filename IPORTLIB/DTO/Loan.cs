using System.Collections.Generic;
namespace DTO
{
    public class Loan
    {
        public int LoanId { get; set; }
        public virtual List<LoanItem> LoanItems { get; set; }
    }
}
