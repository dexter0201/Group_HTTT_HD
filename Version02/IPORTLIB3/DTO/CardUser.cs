using System;
namespace DTO
{
    public class CardUser
    {
		public int CardUserId { get; set; }
		public int UserId { get; set; }
		public string CardUserNo { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool Status { get; set; }
		public DateTime DueDate { get; set; }

    }
}
