using System;
namespace DTO
{
    public class UserEnroll
    {
		public int UserEnrollId { get; set; }
		public int CourseId { get; set; }
		public int GroupId { get; set; }
		public int DepartmentId { get; set; }
		public string UserNo { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime CreatedDate { get; set; }
		public int StatusId { get; set; }

    }
}
