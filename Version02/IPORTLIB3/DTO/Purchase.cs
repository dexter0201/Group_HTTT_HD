using System;
namespace DTO
{
    public class Purchase
    {
		public int PurchaseId { get; set; }
		public DateTime CreatedDate { get; set; }
		public int StatusId { get; set; }
		public string Note { get; set; }

    }
}
