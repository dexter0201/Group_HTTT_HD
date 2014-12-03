using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class UserEnrollment
    {
        public int UserID { get; set; }
        public string FistName { get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public int GroupId { get; set; }
        public DateTime DateRegister { get; set; }
        public int State_ { get; set; }
    }
}
