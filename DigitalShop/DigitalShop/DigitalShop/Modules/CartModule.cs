using System;
using System.Collections.Generic;
using System.Linq;
using DigitalShop.Models;
using DigitalShop.Services;

namespace DigitalShop.Modules
{
    public class CartModule
    {
        private List<CartItem> _items;

        public CartModule()
        {
            _items = StorageService.LoadCart();
        }

        public List<CartItem> GetItems() => _items;
        public decimal GetTotal() => _items.Sum(i => i.Price * i.Quantity);
        public bool IsEmpty() => _items.Count == 0;

        public (bool, string) AddItem(Product product, int quantity)
        {
            try
            {
                if (product.Stock < quantity)
                    return (false, "Недостаточное количество товара");

                var existing = _items.FirstOrDefault(i => i.ProductId == product.Id);
                if (existing != null)
                {
                    if (product.Stock < existing.Quantity + quantity)
                        return (false, "Недостаточно товара на складе");
                    existing.Quantity += quantity;
                }
                else
                {
                    _items.Add(new CartItem
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = quantity
                    });
                }

                StorageService.SaveCart(_items);
                LoggerService.Info($"Добавлен в корзину: {product.Name} x{quantity}");
                return (true, "Товар добавлен в корзину");
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка добавления в корзину: {ex.Message}");
                return (false, "Ошибка добавления");
            }
        }

        public (bool, string) RemoveItem(string productId)
        {
            try
            {
                var item = _items.FirstOrDefault(i => i.ProductId == productId);
                if (item == null)
                    return (false, "Товар не найден в корзине");

                _items.Remove(item);
                StorageService.SaveCart(_items);
                LoggerService.Info($"Удален из корзины: {productId}");
                return (true, "Товар удален из корзины");
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка удаления из корзины: {ex.Message}");
                return (false, "Ошибка удаления");
            }
        }

        public (bool, string) UpdateQuantity(string productId, int newQuantity)
        {
            try
            {
                if (newQuantity <= 0)
                    return RemoveItem(productId);

                var item = _items.FirstOrDefault(i => i.ProductId == productId);
                if (item == null)
                    return (false, "Товар не найден в корзине");

                item.Quantity = newQuantity;
                StorageService.SaveCart(_items);
                LoggerService.Info($"Обновлено количество: {productId} -> {newQuantity}");
                return (true, "Количество обновлено");
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка обновления количества: {ex.Message}");
                return (false, "Ошибка обновления");
            }
        }

        public void Clear()
        {
            _items.Clear();
            StorageService.SaveCart(_items);
            LoggerService.Info("Корзина очищена");
        }
    }
}