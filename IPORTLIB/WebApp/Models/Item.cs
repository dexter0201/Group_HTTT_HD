using System.Collections.Generic;
namespace WebApp.Models
{
    public class Item
    {
        public string Value { get; set; }
        public string Url { get; set; }
        public List<Item> Items { get; set; }
    }
}