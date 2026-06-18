namespace DigitalShop.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string CategoryId { get; set; }
        public string Type { get; set; }

        public Product()
        {
            Id = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Category = string.Empty;
            CategoryId = string.Empty;
            Type = string.Empty;
        }
    }
}