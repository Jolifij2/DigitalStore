using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DigitalShop.Models;

namespace DigitalShop.Services
{
    public static class StorageService
    {
        private static readonly string DataPath = Path.Combine("Data");
        private static readonly string ProductsFile = Path.Combine(DataPath, "products.json");
        private static readonly string OrdersFile = Path.Combine(DataPath, "orders.json");
        private static readonly string CartFile = Path.Combine(DataPath, "cart.json");

        static StorageService()
        {
            try
            {
                if (!Directory.Exists(DataPath))
                    Directory.CreateDirectory(DataPath);
            }
            catch { }
        }

        #region Products
        public static List<Category> LoadProducts()
        {
            try
            {
                if (!File.Exists(ProductsFile))
                    return CreateDefaultProducts();

                string json = File.ReadAllText(ProductsFile);
                var categories = JsonSerializer.Deserialize<List<Category>>(json);
                return categories ?? CreateDefaultProducts();
            }
            catch
            {
                return CreateDefaultProducts();
            }
        }

        public static void SaveProducts(List<Category> categories)
        {
            try
            {
                string json = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ProductsFile, json);
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка сохранения товаров: {ex.Message}");
            }
        }

        private static List<Category> CreateDefaultProducts()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = "cat_01",
                    Name = "Программное обеспечение",
                    Products = new List<Product>
                    {
                        new Product { Id = "pr_001", Name = "Windows 11 Pro", Price = 14999.99m, Stock = 50,
                            Description = "Операционная система", Category = "Программное обеспечение", CategoryId = "cat_01", Type = "software" },
                        new Product { Id = "pr_002", Name = "Microsoft Office 2021", Price = 7999.99m, Stock = 30,
                            Description = "Офисный пакет", Category = "Программное обеспечение", CategoryId = "cat_01", Type = "software" },
                        new Product { Id = "pr_003", Name = "Adobe Photoshop", Price = 12999.99m, Stock = 20,
                            Description = "Графический редактор", Category = "Программное обеспечение", CategoryId = "cat_01", Type = "software" }
                    }
                },
                new Category
                {
                    Id = "cat_02",
                    Name = "Подписки на сервисы",
                    Products = new List<Product>
                    {
                        new Product { Id = "pr_004", Name = "Spotify Premium", Price = 599.99m, Stock = 100,
                            Description = "Музыкальный сервис", Category = "Подписки на сервисы", CategoryId = "cat_02", Type = "subscription" },
                        new Product { Id = "pr_005", Name = "Netflix Standard", Price = 799.99m, Stock = 80,
                            Description = "Видео-сервис", Category = "Подписки на сервисы", CategoryId = "cat_02", Type = "subscription" },
                        new Product { Id = "pr_006", Name = "YouTube Premium", Price = 399.99m, Stock = 120,
                            Description = "Видеохостинг без рекламы", Category = "Подписки на сервисы", CategoryId = "cat_02", Type = "subscription" }
                    }
                },
                new Category
                {
                    Id = "cat_03",
                    Name = "Игры",
                    Products = new List<Product>
                    {
                        new Product { Id = "pr_007", Name = "Cyberpunk 2077", Price = 2999.99m, Stock = 25,
                            Description = "RPG игра", Category = "Игры", CategoryId = "cat_03", Type = "game" },
                        new Product { Id = "pr_008", Name = "The Witcher 3", Price = 1499.99m, Stock = 40,
                            Description = "RPG игра", Category = "Игры", CategoryId = "cat_03", Type = "game" },
                        new Product { Id = "pr_009", Name = "Minecraft", Price = 1999.99m, Stock = 60,
                            Description = "Песочница", Category = "Игры", CategoryId = "cat_03", Type = "game" }
                    }
                },
                new Category
                {
                    Id = "cat_04",
                    Name = "Обучающие курсы",
                    Products = new List<Product>
                    {
                        new Product { Id = "pr_010", Name = "Python для начинающих", Price = 4999.99m, Stock = 15,
                            Description = "Курс по Python", Category = "Обучающие курсы", CategoryId = "cat_04", Type = "course" },
                        new Product { Id = "pr_011", Name = "Веб-разработка Full Stack", Price = 9999.99m, Stock = 10,
                            Description = "Курс по веб-разработке", Category = "Обучающие курсы", CategoryId = "cat_04", Type = "course" },
                        new Product { Id = "pr_012", Name = "Английский язык", Price = 2999.99m, Stock = 20,
                            Description = "Курс английского", Category = "Обучающие курсы", CategoryId = "cat_04", Type = "course" }
                    }
                }
            };

            SaveProducts(categories);
            return categories;
        }
        #endregion

        #region Cart
        public static List<CartItem> LoadCart()
        {
            try
            {
                if (!File.Exists(CartFile))
                    return new List<CartItem>();

                string json = File.ReadAllText(CartFile);
                return JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
            }
            catch
            {
                return new List<CartItem>();
            }
        }

        public static void SaveCart(List<CartItem> cart)
        {
            try
            {
                string json = JsonSerializer.Serialize(cart, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(CartFile, json);
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка сохранения корзины: {ex.Message}");
            }
        }
        #endregion

        #region Orders
        public static List<Order> LoadOrders()
        {
            try
            {
                if (!File.Exists(OrdersFile))
                    return new List<Order>();

                string json = File.ReadAllText(OrdersFile);
                return JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
            }
            catch
            {
                return new List<Order>();
            }
        }

        public static void SaveOrders(List<Order> orders)
        {
            try
            {
                string json = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(OrdersFile, json);
                LoggerService.Info($"Сохранено {orders.Count} заказов");
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка сохранения заказов: {ex.Message}");
            }
        }
        #endregion
    }
}