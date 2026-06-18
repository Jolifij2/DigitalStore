namespace DigitalShop.Forms
{
    partial class CatalogForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private TextBox txtPriceFrom;
        private TextBox txtPriceTo;
        private Button btnClear;
        private DataGridView dgvProducts;
        private Label lblCount;
        private TextBox txtQuantity;
        private Button btnAddToCart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new TextBox();
            this.cmbCategory = new ComboBox();
            this.txtPriceFrom = new TextBox();
            this.txtPriceTo = new TextBox();
            this.btnClear = new Button();
            this.dgvProducts = new DataGridView();
            this.lblCount = new Label();
            this.txtQuantity = new TextBox();
            this.btnAddToCart = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // txtSearch
            this.txtSearch.Location = new Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new Size(200, 27);
            this.txtSearch.Text = "Поиск...";
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);

            // cmbCategory
            this.cmbCategory.Location = new Point(220, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new Size(150, 28);
            this.cmbCategory.SelectedIndexChanged += new EventHandler(this.cmbCategory_SelectedIndexChanged);

            // txtPriceFrom
            this.txtPriceFrom.Location = new Point(380, 12);
            this.txtPriceFrom.Name = "txtPriceFrom";
            this.txtPriceFrom.Size = new Size(70, 27);
            this.txtPriceFrom.Text = "от";
            this.txtPriceFrom.TextChanged += new EventHandler(this.txtPriceFrom_TextChanged);

            // txtPriceTo
            this.txtPriceTo.Location = new Point(460, 12);
            this.txtPriceTo.Name = "txtPriceTo";
            this.txtPriceTo.Size = new Size(70, 27);
            this.txtPriceTo.Text = "до";
            this.txtPriceTo.TextChanged += new EventHandler(this.txtPriceTo_TextChanged);

            // btnClear
            this.btnClear.Location = new Point(540, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(100, 32);
            this.btnClear.Text = "Сбросить";
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // dgvProducts
            this.dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new Point(12, 50);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new Size(780, 350);
            this.dgvProducts.TabIndex = 5;
            this.dgvProducts.Columns.Add("Id", "ID");
            this.dgvProducts.Columns.Add("Name", "Название");
            this.dgvProducts.Columns.Add("Category", "Категория");
            this.dgvProducts.Columns.Add("Price", "Цена");
            this.dgvProducts.Columns.Add("Stock", "В наличии");
            this.dgvProducts.Columns.Add("Description", "Описание");
            this.dgvProducts.Columns[0].Width = 60;
            this.dgvProducts.Columns[1].Width = 180;
            this.dgvProducts.Columns[2].Width = 130;
            this.dgvProducts.Columns[3].Width = 100;
            this.dgvProducts.Columns[4].Width = 70;
            this.dgvProducts.Columns[5].Width = 200;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;

            // lblCount
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new Point(12, 410);
            this.lblCount.Name = "lblCount";
            this.lblCount.Text = "Найдено: 0 товаров";

            // txtQuantity
            this.txtQuantity.Location = new Point(450, 410);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new Size(50, 27);
            this.txtQuantity.Text = "1";

            // btnAddToCart
            this.btnAddToCart.Location = new Point(510, 408);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new Size(180, 32);
            this.btnAddToCart.Text = "➕ Добавить в корзину";
            this.btnAddToCart.Click += new EventHandler(this.btnAddToCart_Click);

            // CatalogForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(804, 451);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtPriceFrom);
            this.Controls.Add(this.txtPriceTo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnAddToCart);
            this.Name = "CatalogForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "📦 Каталог товаров";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}