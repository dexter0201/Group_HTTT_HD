using System.Collections.Generic;
using DTO;

namespace WebApp.Models
{
    public class UtilityUser
    {
        public IEnumerable<User> Users { get; set; }
        public int Count { get; set; }
    }
}