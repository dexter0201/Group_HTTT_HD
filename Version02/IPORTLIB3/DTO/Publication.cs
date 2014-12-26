using System;
namespace DTO
{
    public class Publication
    {
		public int PublicationId { get; set; }
		public int TopicId { get; set; }
		public int AuthorId { get; set; }
		public int PublisherId { get; set; }
		public int PublicationTypeId { get; set; }
		public int MajorId { get; set; }
		public int LanguageId { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public int PublisherYear { get; set; }
		public int? Edition { get; set; }
		public string Copyright { get; set; }
		public string Description { get; set; }
		public string Size { get; set; }
		public int UnitId { get; set; }
		public int Price { get; set; }
		public int CurrencyId { get; set; }
		public int Quantity { get; set; }
		public string NumberDewey { get; set; }
		public string ISBN { get; set; }
		public string Note { get; set; }

    }
}
