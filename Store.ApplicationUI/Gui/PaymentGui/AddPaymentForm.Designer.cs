namespace Store.ApplicationUI.Gui.PaymentGui
{
    partial class AddPaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPaymentForm));
            lblFacture = new Label();
            label2 = new Label();
            label4 = new Label();
            txtFacturePrice = new TextBox();
            txtpaidUp = new TextBox();
            txtRemain = new TextBox();
            PaymentstableLayoutPanel = new TableLayoutPanel();
            button1 = new Button();
            btnConfirmePay = new Button();
            PaymentstableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblFacture
            // 
            lblFacture.Anchor = AnchorStyles.None;
            lblFacture.AutoSize = true;
            lblFacture.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFacture.ImeMode = ImeMode.NoControl;
            lblFacture.Location = new Point(231, 23);
            lblFacture.Name = "lblFacture";
            lblFacture.Size = new Size(115, 23);
            lblFacture.TabIndex = 10;
            lblFacture.Text = "المبلغ المستحق:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 14.25F);
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(257, 93);
            label2.Name = "label2";
            label2.Size = new Size(62, 23);
            label2.TabIndex = 12;
            label2.Text = "المدفوع:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 14.25F);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(266, 163);
            label4.Name = "label4";
            label4.Size = new Size(45, 23);
            label4.TabIndex = 14;
            label4.Text = "الباقي:";
            // 
            // txtFacturePrice
            // 
            txtFacturePrice.Anchor = AnchorStyles.None;
            txtFacturePrice.Font = new Font("Calibri", 12F);
            txtFacturePrice.Location = new Point(3, 17);
            txtFacturePrice.Multiline = true;
            txtFacturePrice.Name = "txtFacturePrice";
            txtFacturePrice.PlaceholderText = "مبلغ الفاتورة";
            txtFacturePrice.ReadOnly = true;
            txtFacturePrice.Size = new Size(186, 36);
            txtFacturePrice.TabIndex = 21;
            txtFacturePrice.TextAlign = HorizontalAlignment.Center;
            txtFacturePrice.KeyPress += txtpaidUp_KeyPress;
            // 
            // txtpaidUp
            // 
            txtpaidUp.Anchor = AnchorStyles.None;
            txtpaidUp.Font = new Font("Calibri", 12F);
            txtpaidUp.Location = new Point(3, 87);
            txtpaidUp.Multiline = true;
            txtpaidUp.Name = "txtpaidUp";
            txtpaidUp.PlaceholderText = "مبلغ الدفع";
            txtpaidUp.Size = new Size(186, 36);
            txtpaidUp.TabIndex = 1;
            txtpaidUp.TextAlign = HorizontalAlignment.Center;
            txtpaidUp.TextChanged += txtpaidUp_TextChanged;
            txtpaidUp.KeyPress += txtpaidUp_KeyPress;
            // 
            // txtRemain
            // 
            txtRemain.Anchor = AnchorStyles.None;
            txtRemain.Font = new Font("Calibri", 12F);
            txtRemain.Location = new Point(3, 157);
            txtRemain.Multiline = true;
            txtRemain.Name = "txtRemain";
            txtRemain.PlaceholderText = "باقي العملية";
            txtRemain.ReadOnly = true;
            txtRemain.Size = new Size(186, 36);
            txtRemain.TabIndex = 21;
            txtRemain.TextAlign = HorizontalAlignment.Center;
            txtRemain.KeyPress += txtpaidUp_KeyPress;
            // 
            // PaymentstableLayoutPanel
            // 
            PaymentstableLayoutPanel.ColumnCount = 2;
            PaymentstableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            PaymentstableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            PaymentstableLayoutPanel.Controls.Add(button1, 1, 3);
            PaymentstableLayoutPanel.Controls.Add(btnConfirmePay, 0, 3);
            PaymentstableLayoutPanel.Controls.Add(txtRemain, 1, 2);
            PaymentstableLayoutPanel.Controls.Add(txtpaidUp, 1, 1);
            PaymentstableLayoutPanel.Controls.Add(txtFacturePrice, 1, 0);
            PaymentstableLayoutPanel.Controls.Add(label4, 0, 2);
            PaymentstableLayoutPanel.Controls.Add(label2, 0, 1);
            PaymentstableLayoutPanel.Controls.Add(lblFacture, 0, 0);
            PaymentstableLayoutPanel.Dock = DockStyle.Fill;
            PaymentstableLayoutPanel.Location = new Point(0, 0);
            PaymentstableLayoutPanel.Name = "PaymentstableLayoutPanel";
            PaymentstableLayoutPanel.RowCount = 4;
            PaymentstableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            PaymentstableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            PaymentstableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            PaymentstableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            PaymentstableLayoutPanel.Size = new Size(384, 315);
            PaymentstableLayoutPanel.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.ForeColor = Color.Red;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(3, 242);
            button1.Name = "button1";
            button1.Size = new Size(186, 40);
            button1.TabIndex = 3;
            button1.Text = "الغاء الدفع";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnConfirmePay
            // 
            btnConfirmePay.Anchor = AnchorStyles.None;
            btnConfirmePay.ForeColor = Color.Green;
            btnConfirmePay.Image = (Image)resources.GetObject("btnConfirmePay.Image");
            btnConfirmePay.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfirmePay.ImeMode = ImeMode.NoControl;
            btnConfirmePay.Location = new Point(195, 242);
            btnConfirmePay.Name = "btnConfirmePay";
            btnConfirmePay.Size = new Size(186, 40);
            btnConfirmePay.TabIndex = 2;
            btnConfirmePay.Text = "ادفع الآن (12)";
            btnConfirmePay.UseVisualStyleBackColor = true;
            btnConfirmePay.Click += btnSearchImage_Click;
            // 
            // AddPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 315);
            Controls.Add(PaymentstableLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(400, 354);
            MinimizeBox = false;
            MinimumSize = new Size(400, 354);
            Name = "AddPaymentForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "بوابة الدفع اليديوية";
            KeyDown += AddPaymentForm_KeyDown;
            PaymentstableLayoutPanel.ResumeLayout(false);
            PaymentstableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblFacture;
        private Label label2;
        private Label label4;
        private TableLayoutPanel PaymentstableLayoutPanel;
        private Button button1;
        private Button btnConfirmePay;
        public TextBox txtFacturePrice;
        public TextBox txtpaidUp;
        public TextBox txtRemain;
    }
}