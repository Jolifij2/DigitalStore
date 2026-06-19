using System;
using System.Collections.Generic;
using System.Linq;
using DigitalShop.Models;
using DigitalShop.Services;

namespace DigitalShop.Modules
{
    public class AdminModule
    {
        private readonly CatalogModule _catalog;

        public AdminModule(CatalogModule catalog)
        {
            _catalog = catalog;
        }

        public List<Order> GetOrders(string statusFilter = null)
        {
            try
            {
                var orders = StorageService.LoadOrders();
                if (!string.IsNullOrEmpty(statusFilter))
                    orders = orders.Where(o => o.Status == statusFilter).ToList();
                return orders;
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка загрузки заказов: {ex.Message}");
                return new List<Order>();
            }
        }

        public (bool, string) ChangeOrderStatus(string orderId, string newStatus)
        {
            try
            {
                var validStatuses = new[] { "новый", "в обработке", "доставлен", "отменен" };
                if (!validStatuses.Contains(newStatus))
                    return (false, "Недопустимый статус");

                var orders = StorageService.LoadOrders();
                var order = orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                    return (false, "Заказ не найден");

                order.Status = newStatus;
                StorageService.SaveOrders(orders);
                LoggerService.Info($"Статус заказа {orderId} изменен на {newStatus}");
                return (true, "Статус заказа обновлен");
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка изменения статуса: {ex.Message}");
                return (false, "Ошибка изменения статуса");
            }
        }

        public bool AddProduct(Product product) => _catalog.AddProduct(product);
        public bool UpdateProduct(string id, Product product) => _catalog.UpdateProduct(id, product);
        public bool DeleteProduct(string id) => _catalog.DeleteProduct(id);
    }
}