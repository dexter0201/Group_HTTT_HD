using System;
namespace DTO
{
    public class PurchaseDetail
    {
		public int PurchaseDetailId { get; set; }
		public int PurchaseId { get; set; }
		public int StatusId { get; set; }
		public string Title { get; set; }
		public string AuthorName { get; set; }
		public int Quantity { get; set; }
		public string Note { get; set; }

    }
}
