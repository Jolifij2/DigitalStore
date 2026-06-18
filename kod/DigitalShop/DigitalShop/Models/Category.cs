using System.Collections.Generic;

namespace DigitalShop.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {
            Id = string.Empty;
            Name = string.Empty;
            Products = new List<Product>();
        }
    }
}