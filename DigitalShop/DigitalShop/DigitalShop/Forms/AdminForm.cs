using System;
using System.Linq;
using System.Windows.Forms;
using DigitalShop.Models;
using DigitalShop.Modules;

namespace DigitalShop.Forms
{
    public partial class AdminForm : Form
    {
        private AdminModule _admin;
        private CatalogModule _catalog;

        public AdminForm(AdminModule admin, CatalogModule catalog)
        {
            InitializeComponent();
            _admin = admin;
            _catalog = catalog;
            LoadOrders();
            LoadProductsAdmin();
            LoadCategories();
        }

        #region Orders
        private void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            var orders = _admin.GetOrders();

            foreach (var order in orders)
            {
                dgvOrders.Rows.Add(
                    order.OrderId,
                    order.CustomerName,
                    order.CustomerPhone,
                    $"{order.TotalAmount:F2}",
                    order.Status,
                    order.OrderDate
                );
            }
        }

        private void btnFilterOrders_Click(object sender, EventArgs e)
        {
            string status = cmbStatusFilter.SelectedItem?.ToString();
            if (status == "Все") status = null;

            dgvOrders.Rows.Clear();
            var orders = _admin.GetOrders(status);

            foreach (var order in orders)
            {
                dgvOrders.Rows.Add(
                    order.OrderId,
                    order.CustomerName,
                    order.CustomerPhone,
                    $"{order.TotalAmount:F2}",
                    order.Status,
                    order.OrderDate
                );
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderId = dgvOrders.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(orderId)) return;

            string newStatus = cmbNewStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("Выберите новый статус", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (success, msg) = _admin.ChangeOrderStatus(orderId, newStatus);
            if (success)
            {
                MessageBox.Show(msg, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            else
            {
                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Products
        private void LoadCategories()
        {
            cmbCategoryAdmin.Items.Clear();
            foreach (var cat in _catalog.GetCategories())
                cmbCategoryAdmin.Items.Add(cat.Name);
            if (cmbCategoryAdmin.Items.Count > 0)
                cmbCategoryAdmin.SelectedIndex = 0;
        }

        private void LoadProductsAdmin()
        {
            dgvProductsAdmin.Rows.Clear();
            var products = _catalog.GetAllProducts();

            foreach (var p in products)
            {
                dgvProductsAdmin.Rows.Add(p.Id, p.Name, p.Category, $"{p.Price:F2}", p.Stock, p.Description);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string catName = cmbCategoryAdmin.SelectedItem?.ToString();
                var category = _catalog.GetCategories().FirstOrDefault(c => c.Name == catName);
                if (category == null)
                {
                    MessageBox.Show("Выберите категорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = new Product
                {
                    Id = txtProductId.Text.Trim(),
                    Name = txtProductName.Text.Trim(),
                    CategoryId = category.Id,
                    Category = category.Name,
                    Price = decimal.Parse(txtProductPrice.Text),
                    Stock = int.Parse(txtProductStock.Text),
                    Description = txtProductDesc.Text.Trim()
                };

                if (string.IsNullOrEmpty(product.Id) || string.IsNullOrEmpty(product.Name))
                {
                    MessageBox.Show("Заполните ID и название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_admin.AddProduct(product))
                {
                    MessageBox.Show("Товар добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearProductForm();
                    LoadProductsAdmin();
                }
                else
                {
                    MessageBox.Show("Ошибка добавления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProductsAdmin.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dgvProductsAdmin.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            if (MessageBox.Show($"Удалить товар {id}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_admin.DeleteProduct(id))
                {
                    MessageBox.Show("Товар удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductsAdmin();
                }
                else
                {
                    MessageBox.Show("Ошибка удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearProductForm()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtProductStock.Clear();
            txtProductDesc.Clear();
        }
        #endregion
    }
}