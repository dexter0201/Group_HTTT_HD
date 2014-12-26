using System;
namespace DTO
{
    public class Book
    {
		public int BookId { get; set; }
		public int PublicationId { get; set; }
		public int StoreId { get; set; }
		public string NumberSpecific { get; set; }
		public bool Status { get; set; }

    }
}
