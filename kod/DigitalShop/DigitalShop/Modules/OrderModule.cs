using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DigitalShop.Models;
using DigitalShop.Services;

namespace DigitalShop.Modules
{
    public class OrderModule
    {
        private readonly CartModule _cart;
        private readonly CatalogModule _catalog;

        public OrderModule(CartModule cart, CatalogModule catalog)
        {
            _cart = cart;
            _catalog = catalog;
        }

        public (bool, List<string>) ValidateOrderData(Order customerData)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(customerData.CustomerName) || customerData.CustomerName.Length < 2)
                errors.Add("Имя должно содержать минимум 2 символа");

            if (!Regex.IsMatch(customerData.CustomerPhone, @"^\+?7\d{10}$|^8\d{10}$"))
                errors.Add("Некорректный формат телефона (пример: +79001234567)");

            if (!Regex.IsMatch(customerData.CustomerEmail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                errors.Add("Некорректный формат email");

            if (string.IsNullOrWhiteSpace(customerData.CustomerAddress) || customerData.CustomerAddress.Length < 5)
                errors.Add("Адрес должен содержать минимум 5 символов");

            if (errors.Count > 0)
                LoggerService.Warning($"Ошибки валидации: {string.Join(", ", errors)}");

            return (errors.Count == 0, errors);
        }

        public (Order, List<string>) CreateOrder(Order customerData)
        {
            try
            {
                var (isValid, errors) = ValidateOrderData(customerData);
                if (!isValid)
                    return (null, errors);

                if (_cart.IsEmpty())
                    return (null, new List<string> { "Корзина пуста" });

                string orderId = GenerateOrderId();

                var items = new List<CartItem>();
                decimal total = 0;

                foreach (var cartItem in _cart.GetItems())
                {
                    var product = _catalog.GetProductById(cartItem.ProductId);
                    if (product == null) continue;

                    if (product.Stock < cartItem.Quantity) continue;

                    items.Add(new CartItem
                    {
                        ProductId = cartItem.ProductId,
                        Name = cartItem.Name,
                        Price = cartItem.Price,
                        Quantity = cartItem.Quantity
                    });
                    total += cartItem.Price * cartItem.Quantity;
                }

                if (items.Count == 0)
                    return (null, new List<string> { "Нет доступных товаров для заказа" });

                var order = new Order
                {
                    OrderId = orderId,
                    CustomerName = customerData.CustomerName.Trim(),
                    CustomerPhone = customerData.CustomerPhone.Trim(),
                    CustomerEmail = customerData.CustomerEmail.Trim(),
                    CustomerAddress = customerData.CustomerAddress.Trim(),
                    OrderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    TotalAmount = total,
                    Status = "новый",
                    Items = items
                };

                var orders = StorageService.LoadOrders();
                orders.Add(order);
                StorageService.SaveOrders(orders);

                _cart.Clear();

                LoggerService.Info($"Заказ {orderId} создан на сумму {total:F2} руб.");
                return (order, new List<string>());
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка создания заказа: {ex.Message}");
                return (null, new List<string> { "Ошибка создания заказа" });
            }
        }

        private string GenerateOrderId()
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            string unique = DateTime.Now.Ticks.ToString().Substring(0, 4);
            return $"DG-{date}-{unique}";
        }
    }
}