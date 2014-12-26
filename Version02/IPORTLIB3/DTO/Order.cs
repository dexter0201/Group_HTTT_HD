using System;
namespace DTO
{
    public class Order
    {
		public int OrderId { get; set; }
		public DateTime CreatedDate { get; set; }
		public int SupplierId { get; set; }
		public int StatusId { get; set; }

    }
}
