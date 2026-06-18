namespace DigitalShop.Forms
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblAddress;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnRefresh;
        private Label lblOrderSummary;
        private TextBox txtOrderSummary;
        private Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new Label();
            this.lblPhone = new Label();
            this.lblEmail = new Label();
            this.lblAddress = new Label();
            this.txtName = new TextBox();
            this.txtPhone = new TextBox();
            this.txtEmail = new TextBox();
            this.txtAddress = new TextBox();
            this.btnSubmit = new Button();
            this.btnClear = new Button();
            this.btnRefresh = new Button();
            this.lblOrderSummary = new Label();
            this.txtOrderSummary = new TextBox();
            this.lblTotal = new Label();

            this.SuspendLayout();

            // Labels
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(12, 15);
            this.lblName.Text = "ФИО *";

            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new Point(12, 55);
            this.lblPhone.Text = "Телефон *";

            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(12, 95);
            this.lblEmail.Text = "Email *";

            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new Point(12, 135);
            this.lblAddress.Text = "Адрес *";

            // TextBoxes
            this.txtName.Location = new Point(120, 12);
            this.txtName.Size = new Size(250, 27);

            this.txtPhone.Location = new Point(120, 52);
            this.txtPhone.Size = new Size(250, 27);

            this.txtEmail.Location = new Point(120, 92);
            this.txtEmail.Size = new Size(250, 27);

            this.txtAddress.Location = new Point(120, 132);
            this.txtAddress.Size = new Size(250, 27);

            // Order Summary
            this.lblOrderSummary.AutoSize = true;
            this.lblOrderSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblOrderSummary.Location = new Point(400, 15);
            this.lblOrderSummary.Text = "Состав заказа";

            this.txtOrderSummary.Location = new Point(400, 40);
            this.txtOrderSummary.Multiline = true;
            this.txtOrderSummary.Size = new Size(280, 120);
            this.txtOrderSummary.ReadOnly = true;

            // Total
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotal.Location = new Point(400, 175);
            this.lblTotal.Text = "Итого: 0.00 руб.";

            // Buttons
            this.btnSubmit.Location = new Point(12, 180);
            this.btnSubmit.Size = new Size(180, 40);
            this.btnSubmit.Text = "✅ Оформить заказ";
            this.btnSubmit.BackColor = System.Drawing.Color.Green;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            this.btnClear.Location = new Point(200, 180);
            this.btnClear.Size = new Size(170, 40);
            this.btnClear.Text = "🔄 Очистить форму";
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            this.btnRefresh.Location = new Point(400, 210);
            this.btnRefresh.Size = new Size(280, 30);
            this.btnRefresh.Text = "🔄 Обновить состав";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // OrderForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 265);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblOrderSummary);
            this.Controls.Add(this.txtOrderSummary);
            this.Controls.Add(this.lblTotal);
            this.Name = "OrderForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "📝 Оформление заказа";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}