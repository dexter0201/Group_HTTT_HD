using System.Collections.Generic;
namespace WebApp.Models
{
    public class Model<T>
    {
        public int Page { get; set; }
        public IEnumerable<T> Objs { get; set; }
    }
}