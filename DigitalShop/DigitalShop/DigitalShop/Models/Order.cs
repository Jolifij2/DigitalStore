using System.Collections.Generic;

namespace DigitalShop.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<CartItem> Items { get; set; }

        public Order()
        {
            OrderId = string.Empty;
            CustomerName = string.Empty;
            CustomerPhone = string.Empty;
            CustomerEmail = string.Empty;
            CustomerAddress = string.Empty;
            OrderDate = string.Empty;
            Status = "новый";
            Items = new List<CartItem>();
        }
    }
}