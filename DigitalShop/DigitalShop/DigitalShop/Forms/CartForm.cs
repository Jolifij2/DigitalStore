using System;
using System.Linq;
using System.Windows.Forms;
using DigitalShop.Modules;

namespace DigitalShop.Forms
{
    public partial class CartForm : Form
    {
        private CartModule _cart;
        private CatalogModule _catalog;
        private Action _updateCart;

        public CartForm(CartModule cart, CatalogModule catalog, Action updateCart)
        {
            InitializeComponent();
            _cart = cart;
            _catalog = catalog;
            _updateCart = updateCart;
            LoadCart();
        }

        private void LoadCart()
        {
            dgvCart.Rows.Clear();
            var items = _cart.GetItems();

            foreach (var item in items)
            {
                dgvCart.Rows.Add(item.ProductId, item.Name, $"{item.Price:F2}", item.Quantity, $"{item.Price * item.Quantity:F2}");
            }

            lblTotal.Text = $"Итого: {_cart.GetTotal():F2} руб.";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productId = dgvCart.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(productId)) return;

            if (MessageBox.Show("Удалить товар из корзины?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var (success, msg) = _cart.RemoveItem(productId);
                if (success)
                {
                    LoadCart();
                    _updateCart?.Invoke();
                    MessageBox.Show(msg, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productId = dgvCart.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(productId)) return;

            if (!int.TryParse(txtNewQuantity.Text, out int newQty) || newQty <= 0)
            {
                MessageBox.Show("Введите корректное количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (success, msg) = _cart.UpdateQuantity(productId, newQty);
            if (success)
            {
                LoadCart();
                _updateCart?.Invoke();
                MessageBox.Show(msg, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_cart.IsEmpty())
            {
                MessageBox.Show("Корзина уже пуста", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Очистить корзину?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cart.Clear();
                LoadCart();
                _updateCart?.Invoke();
                MessageBox.Show("Корзина очищена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCart();
            _updateCart?.Invoke();
        }
    }
}