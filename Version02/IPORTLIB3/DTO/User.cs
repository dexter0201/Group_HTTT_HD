using System;
namespace DTO
{
    public class User
    {
		public int UserId { get; set; }
		public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
		public int? ProvinceId { get; set; }
		public int GroupId { get; set; }
		public int? AttachmentId { get; set; }
		public string UserNo { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool? Gender { get; set; }
		public DateTime BirthDay { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string IdentityCard { get; set; }
		public string Email { get; set; }


        public int CountLoan { get; set; }
    }
}
