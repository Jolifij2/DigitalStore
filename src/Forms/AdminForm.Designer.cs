namespace DigitalShop.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        // Вкладки
        private TabControl tabControl;
        private TabPage tabOrders;
        private TabPage tabProducts;

        // Orders
        private DataGridView dgvOrders;
        private ComboBox cmbStatusFilter;
        private Button btnFilterOrders;
        private ComboBox cmbNewStatus;
        private Button btnChangeStatus;
        private Label lblStatusFilter;
        private Label lblNewStatus;

        // Products
        private DataGridView dgvProductsAdmin;
        private Label lblProductId;
        private Label lblProductName;
        private Label lblProductCategory;
        private Label lblProductPrice;
        private Label lblProductStock;
        private Label lblProductDesc;
        private TextBox txtProductId;
        private TextBox txtProductName;
        private ComboBox cmbCategoryAdmin;
        private TextBox txtProductPrice;
        private TextBox txtProductStock;
        private TextBox txtProductDesc;
        private Button btnAddProduct;
        private Button btnDeleteProduct;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new TabControl();
            this.tabOrders = new TabPage();
            this.tabProducts = new TabPage();

            // ===== TAB ORDERS =====
            this.dgvOrders = new DataGridView();
            this.cmbStatusFilter = new ComboBox();
            this.btnFilterOrders = new Button();
            this.cmbNewStatus = new ComboBox();
            this.btnChangeStatus = new Button();
            this.lblStatusFilter = new Label();
            this.lblNewStatus = new Label();

            // dgvOrders
            this.dgvOrders.Location = new Point(10, 50);
            this.dgvOrders.Size = new Size(760, 250);
            this.dgvOrders.Columns.Add("OrderId", "Номер");
            this.dgvOrders.Columns.Add("Customer", "Клиент");
            this.dgvOrders.Columns.Add("Phone", "Телефон");
            this.dgvOrders.Columns.Add("Total", "Сумма");
            this.dgvOrders.Columns.Add("Status", "Статус");
            this.dgvOrders.Columns.Add("Date", "Дата");
            this.dgvOrders.Columns[0].Width = 120;
            this.dgvOrders.Columns[1].Width = 150;
            this.dgvOrders.Columns[2].Width = 120;
            this.dgvOrders.Columns[3].Width = 100;
            this.dgvOrders.Columns[4].Width = 100;
            this.dgvOrders.Columns[5].Width = 150;
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect = false;

            // cmbStatusFilter
            this.cmbStatusFilter.Location = new Point(120, 12);
            this.cmbStatusFilter.Size = new Size(130, 28);
            this.cmbStatusFilter.Items.AddRange(new object[] { "Все", "новый", "в обработке", "доставлен", "отменен" });
            this.cmbStatusFilter.SelectedIndex = 0;

            // btnFilterOrders
            this.btnFilterOrders.Location = new Point(260, 10);
            this.btnFilterOrders.Size = new Size(100, 32);
            this.btnFilterOrders.Text = "Фильтр";
            this.btnFilterOrders.Click += new EventHandler(this.btnFilterOrders_Click);

            // lblStatusFilter
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new Point(10, 16);
            this.lblStatusFilter.Text = "Фильтр:";

            // cmbNewStatus
            this.cmbNewStatus.Location = new Point(120, 315);
            this.cmbNewStatus.Size = new Size(130, 28);
            this.cmbNewStatus.Items.AddRange(new object[] { "в обработке", "доставлен", "отменен" });
            this.cmbNewStatus.SelectedIndex = 0;

            // btnChangeStatus
            this.btnChangeStatus.Location = new Point(260, 313);
            this.btnChangeStatus.Size = new Size(150, 32);
            this.btnChangeStatus.Text = "Изменить статус";
            this.btnChangeStatus.Click += new EventHandler(this.btnChangeStatus_Click);

            // lblNewStatus
            this.lblNewStatus.AutoSize = true;
            this.lblNewStatus.Location = new Point(10, 319);
            this.lblNewStatus.Text = "Новый статус:";

            this.tabOrders.Controls.Add(this.lblStatusFilter);
            this.tabOrders.Controls.Add(this.cmbStatusFilter);
            this.tabOrders.Controls.Add(this.btnFilterOrders);
            this.tabOrders.Controls.Add(this.dgvOrders);
            this.tabOrders.Controls.Add(this.lblNewStatus);
            this.tabOrders.Controls.Add(this.cmbNewStatus);
            this.tabOrders.Controls.Add(this.btnChangeStatus);
            this.tabOrders.Text = "📋 Заказы";

            // ===== TAB PRODUCTS =====
            this.dgvProductsAdmin = new DataGridView();

            this.lblProductId = new Label();
            this.lblProductName = new Label();
            this.lblProductCategory = new Label();
            this.lblProductPrice = new Label();
            this.lblProductStock = new Label();
            this.lblProductDesc = new Label();

            this.txtProductId = new TextBox();
            this.txtProductName = new TextBox();
            this.cmbCategoryAdmin = new ComboBox();
            this.txtProductPrice = new TextBox();
            this.txtProductStock = new TextBox();
            this.txtProductDesc = new TextBox();

            this.btnAddProduct = new Button();
            this.btnDeleteProduct = new Button();

            // dgvProductsAdmin
            this.dgvProductsAdmin.Location = new Point(10, 12);
            this.dgvProductsAdmin.Size = new Size(480, 300);
            this.dgvProductsAdmin.Columns.Add("Id", "ID");
            this.dgvProductsAdmin.Columns.Add("Name", "Название");
            this.dgvProductsAdmin.Columns.Add("Category", "Категория");
            this.dgvProductsAdmin.Columns.Add("Price", "Цена");
            this.dgvProductsAdmin.Columns.Add("Stock", "В наличии");
            this.dgvProductsAdmin.Columns.Add("Desc", "Описание");
            this.dgvProductsAdmin.Columns[0].Width = 60;
            this.dgvProductsAdmin.Columns[1].Width = 120;
            this.dgvProductsAdmin.Columns[2].Width = 80;
            this.dgvProductsAdmin.Columns[3].Width = 70;
            this.dgvProductsAdmin.Columns[4].Width = 60;
            this.dgvProductsAdmin.Columns[5].Width = 100;
            this.dgvProductsAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductsAdmin.MultiSelect = false;

            // Labels
            this.lblProductId.Location = new Point(500, 12);
            this.lblProductId.Text = "ID:";
            this.lblProductId.Size = new Size(40, 25);

            this.lblProductName.Location = new Point(500, 52);
            this.lblProductName.Text = "Название:";
            this.lblProductName.Size = new Size(80, 25);

            this.lblProductCategory.Location = new Point(500, 92);
            this.lblProductCategory.Text = "Категория:";
            this.lblProductCategory.Size = new Size(80, 25);

            this.lblProductPrice.Location = new Point(500, 132);
            this.lblProductPrice.Text = "Цена:";
            this.lblProductPrice.Size = new Size(80, 25);

            this.lblProductStock.Location = new Point(500, 172);
            this.lblProductStock.Text = "Кол-во:";
            this.lblProductStock.Size = new Size(80, 25);

            this.lblProductDesc.Location = new Point(500, 212);
            this.lblProductDesc.Text = "Описание:";
            this.lblProductDesc.Size = new Size(80, 25);

            // TextBoxes
            this.txtProductId.Location = new Point(590, 10);
            this.txtProductId.Size = new Size(170, 27);

            this.txtProductName.Location = new Point(590, 50);
            this.txtProductName.Size = new Size(170, 27);

            this.cmbCategoryAdmin.Location = new Point(590, 90);
            this.cmbCategoryAdmin.Size = new Size(170, 28);

            this.txtProductPrice.Location = new Point(590, 130);
            this.txtProductPrice.Size = new Size(170, 27);

            this.txtProductStock.Location = new Point(590, 170);
            this.txtProductStock.Size = new Size(170, 27);

            this.txtProductDesc.Location = new Point(590, 210);
            this.txtProductDesc.Size = new Size(170, 60);
            this.txtProductDesc.Multiline = true;

            // Buttons
            this.btnAddProduct.Location = new Point(500, 290);
            this.btnAddProduct.Size = new Size(120, 35);
            this.btnAddProduct.Text = "➕ Добавить";
            this.btnAddProduct.BackColor = System.Drawing.Color.Green;
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Click += new EventHandler(this.btnAddProduct_Click);

            this.btnDeleteProduct.Location = new Point(630, 290);
            this.btnDeleteProduct.Size = new Size(120, 35);
            this.btnDeleteProduct.Text = "🗑️ Удалить";
            this.btnDeleteProduct.BackColor = System.Drawing.Color.Red;
            this.btnDeleteProduct.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProduct.Click += new EventHandler(this.btnDeleteProduct_Click);

            this.tabProducts.Controls.Add(this.dgvProductsAdmin);
            this.tabProducts.Controls.Add(this.lblProductId);
            this.tabProducts.Controls.Add(this.lblProductName);
            this.tabProducts.Controls.Add(this.lblProductCategory);
            this.tabProducts.Controls.Add(this.lblProductPrice);
            this.tabProducts.Controls.Add(this.lblProductStock);
            this.tabProducts.Controls.Add(this.lblProductDesc);
            this.tabProducts.Controls.Add(this.txtProductId);
            this.tabProducts.Controls.Add(this.txtProductName);
            this.tabProducts.Controls.Add(this.cmbCategoryAdmin);
            this.tabProducts.Controls.Add(this.txtProductPrice);
            this.tabProducts.Controls.Add(this.txtProductStock);
            this.tabProducts.Controls.Add(this.txtProductDesc);
            this.tabProducts.Controls.Add(this.btnAddProduct);
            this.tabProducts.Controls.Add(this.btnDeleteProduct);
            this.tabProducts.Text = "📦 Товары";

            // ===== TAB CONTROL =====
            this.tabControl.Controls.Add(this.tabOrders);
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Dock = DockStyle.Fill;

            // AdminForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 381);
            this.Controls.Add(this.tabControl);
            this.Name = "AdminForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "⚙️ Административная панель";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}