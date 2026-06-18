namespace DigitalShop.Models
{
    public class CartItem
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public CartItem()
        {
            ProductId = string.Empty;
            Name = string.Empty;
        }
    }
}