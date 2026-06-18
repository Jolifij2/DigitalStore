using System;
using System.Collections.Generic;
using System.Linq;
using DigitalShop.Models;
using DigitalShop.Services;

namespace DigitalShop.Modules
{
    public class CatalogModule
    {
        private List<Category> _categories;
        private List<Product> _allProducts;

        public CatalogModule()
        {
            _categories = StorageService.LoadProducts();
            _allProducts = _categories.SelectMany(c => c.Products).ToList();
            LoggerService.Info($"Загружено {_allProducts.Count} товаров");
        }

        public List<Product> GetAllProducts() => _allProducts;
        public List<Category> GetCategories() => _categories;

        public List<Product> SearchByName(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return _allProducts;

            return _allProducts.Where(p => p.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public List<Product> FilterByCategory(string categoryId)
        {
            return _allProducts.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> FilterByPrice(decimal min, decimal max)
        {
            return _allProducts.Where(p => p.Price >= min && p.Price <= max).ToList();
        }

        public Product GetProductById(string id)
        {
            return _allProducts.FirstOrDefault(p => p.Id == id);
        }

        public bool AddProduct(Product product)
        {
            try
            {
                var category = _categories.FirstOrDefault(c => c.Id == product.CategoryId);
                if (category == null) return false;

                category.Products.Add(product);
                _allProducts.Add(product);
                StorageService.SaveProducts(_categories);
                LoggerService.Info($"Добавлен товар: {product.Name}");
                return true;
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка добавления товара: {ex.Message}");
                return false;
            }
        }

        public bool UpdateProduct(string id, Product updatedData)
        {
            try
            {
                var product = GetProductById(id);
                if (product == null) return false;

                if (!string.IsNullOrEmpty(updatedData.Name)) product.Name = updatedData.Name;
                if (updatedData.Price > 0) product.Price = updatedData.Price;
                if (updatedData.Stock >= 0) product.Stock = updatedData.Stock;
                if (!string.IsNullOrEmpty(updatedData.Description)) product.Description = updatedData.Description;

                StorageService.SaveProducts(_categories);
                LoggerService.Info($"Обновлен товар: {id}");
                return true;
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка обновления товара: {ex.Message}");
                return false;
            }
        }

        public bool DeleteProduct(string id)
        {
            try
            {
                foreach (var category in _categories)
                {
                    category.Products.RemoveAll(p => p.Id == id);
                }
                _allProducts.RemoveAll(p => p.Id == id);

                StorageService.SaveProducts(_categories);
                LoggerService.Info($"Удален товар: {id}");
                return true;
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка удаления товара: {ex.Message}");
                return false;
            }
        }
    }
}