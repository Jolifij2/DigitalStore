using DigitalShop.Models;
using DigitalShop.Modules;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DigitalShop.Forms
{
    public partial class OrderForm : Form
    {
        private OrderModule _order;
        private CartModule _cart;
        private Action _updateCart;

        public OrderForm(OrderModule order, CartModule cart, Action updateCart)
        {
            InitializeComponent();
            _order = order;
            _cart = cart;
            _updateCart = updateCart;
            UpdateOrderSummary();
        }

        private void UpdateOrderSummary()
        {
            txtOrderSummary.Clear();
            var items = _cart.GetItems();

            if (items.Count == 0)
            {
                txtOrderSummary.Text = "Корзина пуста";
                lblTotal.Text = "Итого: 0.00 руб.";
                return;
            }

            foreach (var item in items)
            {
                txtOrderSummary.AppendText($"• {item.Name} x{item.Quantity} = {item.Price * item.Quantity:F2} руб.\n");
            }

            lblTotal.Text = $"Итого: {_cart.GetTotal():F2} руб.";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_cart.IsEmpty())
            {
                MessageBox.Show("Корзина пуста! Добавьте товары.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customerData = new Order
            {
                CustomerName = txtName.Text.Trim(),
                CustomerPhone = txtPhone.Text.Trim(),
                CustomerEmail = txtEmail.Text.Trim(),
                CustomerAddress = txtAddress.Text.Trim()
            };

            var (order, errors) = _order.CreateOrder(customerData);

            if (order != null)
            {
                MessageBox.Show(
                    $"✅ Заказ успешно оформлен!\n\n" +
                    $"Номер заказа: {order.OrderId}\n" +
                    $"Сумма: {order.TotalAmount:F2} руб.\n" +
                    $"Статус: {order.Status}\n" +
                    $"Дата: {order.OrderDate}\n\n" +
                    $"Спасибо за покупку!",
                    "Заказ оформлен",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearForm();
                UpdateOrderSummary();
                _updateCart?.Invoke();
            }
            else
            {
                string errorMsg = string.Join("\n", errors);
                MessageBox.Show($"Ошибка оформления заказа:\n{errorMsg}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateOrderSummary();
            _updateCart?.Invoke();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
        }
    }
}