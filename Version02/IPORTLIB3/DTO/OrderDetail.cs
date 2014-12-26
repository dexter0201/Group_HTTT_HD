using System;
namespace DTO
{
    public class OrderDetail
    {
		public int OrderDetailId { get; set; }
		public int OrderId { get; set; }
		public int PurchaseDetailId { get; set; }
		public int? Price { get; set; }
		public int Quantity { get; set; }
		public int StatusId { get; set; }

    }
}
