namespace DigitalShop.Forms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCart;
        private Label lblTotal;
        private Button btnRemove;
        private Button btnUpdateQuantity;
        private TextBox txtNewQuantity;
        private Button btnClear;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCart = new DataGridView();
            this.lblTotal = new Label();
            this.btnRemove = new Button();
            this.btnUpdateQuantity = new Button();
            this.txtNewQuantity = new TextBox();
            this.btnClear = new Button();
            this.btnRefresh = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            // dgvCart
            this.dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new Point(12, 12);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new Size(700, 300);
            this.dgvCart.TabIndex = 0;
            this.dgvCart.Columns.Add("Id", "ID");
            this.dgvCart.Columns.Add("Name", "Название");
            this.dgvCart.Columns.Add("Price", "Цена");
            this.dgvCart.Columns.Add("Quantity", "Кол-во");
            this.dgvCart.Columns.Add("Total", "Сумма");
            this.dgvCart.Columns[0].Width = 80;
            this.dgvCart.Columns[1].Width = 250;
            this.dgvCart.Columns[2].Width = 100;
            this.dgvCart.Columns[3].Width = 80;
            this.dgvCart.Columns[4].Width = 120;
            this.dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.MultiSelect = false;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTotal.Location = new Point(12, 330);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Итого: 0.00 руб.";

            // btnRemove
            this.btnRemove.Location = new Point(12, 380);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new Size(150, 32);
            this.btnRemove.Text = "🗑️ Удалить";
            this.btnRemove.Click += new EventHandler(this.btnRemove_Click);

            // btnUpdateQuantity
            this.btnUpdateQuantity.Location = new Point(170, 380);
            this.btnUpdateQuantity.Name = "btnUpdateQuantity";
            this.btnUpdateQuantity.Size = new Size(150, 32);
            this.btnUpdateQuantity.Text = "🔄 Обновить кол-во";
            this.btnUpdateQuantity.Click += new EventHandler(this.btnUpdateQuantity_Click);

            // txtNewQuantity
            this.txtNewQuantity.Location = new Point(330, 382);
            this.txtNewQuantity.Name = "txtNewQuantity";
            this.txtNewQuantity.Size = new Size(50, 27);
            this.txtNewQuantity.Text = "1";

            // btnClear
            this.btnClear.Location = new Point(400, 380);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(150, 32);
            this.btnClear.Text = "🗑️ Очистить";
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // btnRefresh
            this.btnRefresh.Location = new Point(560, 380);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(150, 32);
            this.btnRefresh.Text = "🔄 Обновить";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // CartForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(724, 430);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdateQuantity);
            this.Controls.Add(this.txtNewQuantity);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRefresh);
            this.Name = "CartForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "🛒 Корзина";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}