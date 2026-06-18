using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DigitalShop.Models;
using DigitalShop.Modules;

namespace DigitalShop.Forms
{
    public partial class CatalogForm : Form
    {
        private CatalogModule _catalog;
        private CartModule _cart;
        private Action _updateCart;
        private List<Product> _currentProducts;

        public CatalogForm(CatalogModule catalog, CartModule cart, Action updateCart)
        {
            InitializeComponent();
            _catalog = catalog;
            _cart = cart;
            _updateCart = updateCart;
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Все категории");
            foreach (var cat in _catalog.GetCategories())
                cmbCategory.Items.Add(cat.Name);
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            var products = _catalog.GetAllProducts();
            _currentProducts = products;
            dgvProducts.Rows.Clear();

            foreach (var p in products)
            {
                dgvProducts.Rows.Add(p.Id, p.Name, p.Category, $"{p.Price:F2}", p.Stock, p.Description);
            }

            lblCount.Text = $"Найдено: {products.Count} товаров";
        }

        private void ApplyFilters()
        {
            var products = _catalog.GetAllProducts();

            // Поиск
            string search = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(search))
                products = products.Where(p => p.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            // Категория
            if (cmbCategory.SelectedItem?.ToString() != "Все категории")
            {
                var catName = cmbCategory.SelectedItem?.ToString();
                products = products.Where(p => p.Category == catName).ToList();
            }

            // Цена
            if (decimal.TryParse(txtPriceFrom.Text, out decimal from))
                products = products.Where(p => p.Price >= from).ToList();
            if (decimal.TryParse(txtPriceTo.Text, out decimal to))
                products = products.Where(p => p.Price <= to).ToList();

            _currentProducts = products;
            dgvProducts.Rows.Clear();
            foreach (var p in products)
            {
                dgvProducts.Rows.Add(p.Id, p.Name, p.Category, $"{p.Price:F2}", p.Stock, p.Description);
            }
            lblCount.Text = $"Найдено: {products.Count} товаров";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilters();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();
        private void txtPriceFrom_TextChanged(object sender, EventArgs e) => ApplyFilters();
        private void txtPriceTo_TextChanged(object sender, EventArgs e) => ApplyFilters();

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            txtPriceFrom.Clear();
            txtPriceTo.Clear();
            LoadProducts();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productId = dgvProducts.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(productId)) return;

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = _catalog.GetProductById(productId);
            if (product == null)
            {
                MessageBox.Show("Товар не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var (success, msg) = _cart.AddItem(product, quantity);
            if (success)
            {
                MessageBox.Show($"Товар добавлен в корзину!\n{msg}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _updateCart?.Invoke();
            }
            else
            {
                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}