using System;
using System.Collections.Generic;
namespace DTO
{
    public class Course
    {
		public int CourseId { get; set; }
		public int Quantity { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Note { get; set; }
        public virtual IEnumerable<UserEnroll> UserEnrolls { get; set; }
    }
}
