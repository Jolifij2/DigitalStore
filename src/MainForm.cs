using System;
using System.Windows.Forms;
using DigitalShop.Modules;
using DigitalShop.Forms;

namespace DigitalShop
{
    public partial class MainForm : Form
    {
        private CatalogModule _catalog;
        private CartModule _cart;
        private OrderModule _order;
        private AdminModule _admin;

        public MainForm()
        {
            InitializeComponent();
            InitializeModules();
            UpdateCartInfo();
        }

        private void InitializeModules()
        {
            _catalog = new CatalogModule();
            _cart = new CartModule();
            _order = new OrderModule(_cart, _catalog);
            _admin = new AdminModule(_catalog);
        }

        private void UpdateCartInfo()
        {
            int count = 0;
            decimal total = 0;
            foreach (var item in _cart.GetItems())
            {
                count += item.Quantity;
                total += item.Price * item.Quantity;
            }
            lblCartInfo.Text = $"🛒 Корзина: {count} товаров | {total:F2} руб.";
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            var form = new CatalogForm(_catalog, _cart, UpdateCartInfo);
            form.ShowDialog();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            var form = new CartForm(_cart, _catalog, UpdateCartInfo);
            form.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            var form = new OrderForm(_order, _cart, UpdateCartInfo);
            form.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var form = new AdminForm(_admin, _catalog);
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из приложения?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void UpdateCartInfoFromForm() => UpdateCartInfo();
    }
}