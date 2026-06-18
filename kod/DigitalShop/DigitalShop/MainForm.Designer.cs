namespace DigitalShop
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblCartInfo;
        private Button btnCatalog;
        private Button btnCart;
        private Button btnOrder;
        private Button btnAdmin;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblCartInfo = new Label();
            this.btnCatalog = new Button();
            this.btnCart = new Button();
            this.btnOrder = new Button();
            this.btnAdmin = new Button();
            this.btnExit = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(271, 45);
            this.lblTitle.Text = "💾 DigitalShop";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblCartInfo
            this.lblCartInfo.AutoSize = true;
            this.lblCartInfo.Font = new Font("Segoe UI", 12F);
            this.lblCartInfo.Location = new Point(60, 80);
            this.lblCartInfo.Name = "lblCartInfo";
            this.lblCartInfo.Size = new Size(200, 28);
            this.lblCartInfo.Text = "🛒 Корзина: 0 товаров | 0 руб.";

            // btnCatalog
            this.btnCatalog.Font = new Font("Segoe UI", 14F);
            this.btnCatalog.Location = new Point(60, 140);
            this.btnCatalog.Name = "btnCatalog";
            this.btnCatalog.Size = new Size(300, 60);
            this.btnCatalog.Text = "📦 Каталог";
            this.btnCatalog.UseVisualStyleBackColor = true;
            this.btnCatalog.Click += new EventHandler(this.btnCatalog_Click);

            // btnCart
            this.btnCart.Font = new Font("Segoe UI", 14F);
            this.btnCart.Location = new Point(60, 220);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new Size(300, 60);
            this.btnCart.Text = "🛒 Корзина";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new EventHandler(this.btnCart_Click);

            // btnOrder
            this.btnOrder.Font = new Font("Segoe UI", 14F);
            this.btnOrder.Location = new Point(60, 300);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new Size(300, 60);
            this.btnOrder.Text = "📝 Оформить заказ";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new EventHandler(this.btnOrder_Click);

            // btnAdmin
            this.btnAdmin.Font = new Font("Segoe UI", 14F);
            this.btnAdmin.Location = new Point(60, 380);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new Size(300, 60);
            this.btnAdmin.Text = "⚙️ Админ панель";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new EventHandler(this.btnAdmin_Click);

            // btnExit
            this.btnExit.Font = new Font("Segoe UI", 12F);
            this.btnExit.Location = new Point(60, 470);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(300, 50);
            this.btnExit.Text = "🚪 Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // MainForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(420, 560);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCartInfo);
            this.Controls.Add(this.btnCatalog);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnExit);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "DigitalShop - Цифровой магазин";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}