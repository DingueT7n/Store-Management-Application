namespace Store.ApplicationUI.Gui.ProductsGui.ProductDiscountGui
{
    partial class AddProductDiscountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductDiscountForm));
            groupBox1 = new GroupBox();
            txtSalePrice = new TextBox();
            label7 = new Label();
            txtDiscountValue = new TextBox();
            label6 = new Label();
            btnTransfert = new Button();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            txtQtyInFrom = new TextBox();
            label10 = new Label();
            txtQtyTransfert = new TextBox();
            label5 = new Label();
            label4 = new Label();
            cmbStoresFrom = new ComboBox();
            txtTotalQty = new TextBox();
            label3 = new Label();
            txtProductName = new TextBox();
            label2 = new Label();
            txtBareCode = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSalePrice);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtDiscountValue);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnTransfert);
            groupBox1.Controls.Add(lblFrom);
            groupBox1.Controls.Add(dtpFrom);
            groupBox1.Controls.Add(lblTo);
            groupBox1.Controls.Add(dtpTo);
            groupBox1.Controls.Add(txtQtyInFrom);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtQtyTransfert);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbStoresFrom);
            groupBox1.Controls.Add(txtTotalQty);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtBareCode);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(425, 488);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "معلومات التخفيض";
            // 
            // txtSalePrice
            // 
            txtSalePrice.Location = new Point(228, 287);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(110, 27);
            txtSalePrice.TabIndex = 40;
            txtSalePrice.Text = "0";
            txtSalePrice.KeyPress += xtTotalQty_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(344, 291);
            label7.Name = "label7";
            label7.Size = new Size(65, 19);
            label7.TabIndex = 39;
            label7.Text = "سعر البيع:";
            // 
            // txtDiscountValue
            // 
            txtDiscountValue.Location = new Point(18, 287);
            txtDiscountValue.Name = "txtDiscountValue";
            txtDiscountValue.Size = new Size(107, 27);
            txtDiscountValue.TabIndex = 38;
            txtDiscountValue.Text = "0";
            txtDiscountValue.KeyPress += xtTotalQty_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(131, 291);
            label6.Name = "label6";
            label6.Size = new Size(91, 19);
            label6.TabIndex = 37;
            label6.Text = "سعر التخفيض:";
            // 
            // btnTransfert
            // 
            btnTransfert.Anchor = AnchorStyles.None;
            btnTransfert.Image = (Image)resources.GetObject("btnTransfert.Image");
            btnTransfert.ImageAlign = ContentAlignment.MiddleLeft;
            btnTransfert.ImeMode = ImeMode.NoControl;
            btnTransfert.Location = new Point(85, 435);
            btnTransfert.Name = "btnTransfert";
            btnTransfert.Size = new Size(218, 40);
            btnTransfert.TabIndex = 36;
            btnTransfert.Text = "اتمام العملية";
            btnTransfert.UseVisualStyleBackColor = true;
            btnTransfert.Click += btnTransfert_Click;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(369, 346);
            lblFrom.Margin = new Padding(5, 10, 5, 5);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(28, 19);
            lblFrom.TabIndex = 32;
            lblFrom.Text = "من:";
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(240, 341);
            dtpFrom.Margin = new Padding(5);
            dtpFrom.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(119, 27);
            dtpFrom.TabIndex = 35;
            dtpFrom.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ImeMode = ImeMode.NoControl;
            lblTo.Location = new Point(181, 347);
            lblTo.Margin = new Padding(5, 10, 5, 5);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 19);
            lblTo.TabIndex = 33;
            lblTo.Text = "الى:";
            // 
            // dtpTo
            // 
            dtpTo.CustomFormat = "yyyy-MM-dd";
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(49, 341);
            dtpTo.Margin = new Padding(5);
            dtpTo.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(119, 27);
            dtpTo.TabIndex = 34;
            dtpTo.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // txtQtyInFrom
            // 
            txtQtyInFrom.Enabled = false;
            txtQtyInFrom.Location = new Point(18, 186);
            txtQtyInFrom.Name = "txtQtyInFrom";
            txtQtyInFrom.Size = new Size(160, 27);
            txtQtyInFrom.TabIndex = 20;
            txtQtyInFrom.Text = "0";
            txtQtyInFrom.KeyPress += txtTotalQty_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(210, 189);
            label10.Name = "label10";
            label10.Size = new Size(199, 19);
            label10.TabIndex = 19;
            label10.Text = "الكمية الموجودة في المخزن المحدد:";
            // 
            // txtQtyTransfert
            // 
            txtQtyTransfert.Location = new Point(18, 236);
            txtQtyTransfert.Name = "txtQtyTransfert";
            txtQtyTransfert.Size = new Size(160, 27);
            txtQtyTransfert.TabIndex = 18;
            txtQtyTransfert.Text = "0";
            txtQtyTransfert.KeyPress += txtTotalQty_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(187, 239);
            label5.Name = "label5";
            label5.Size = new Size(223, 19);
            label5.TabIndex = 17;
            label5.Text = "الكمية المنتجات المراد التخفيض عليها :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 140);
            label4.Name = "label4";
            label4.Size = new Size(181, 19);
            label4.TabIndex = 16;
            label4.Text = "المخزن المراد عمل تخفيض فيه:";
            // 
            // cmbStoresFrom
            // 
            cmbStoresFrom.FormattingEnabled = true;
            cmbStoresFrom.Location = new Point(18, 137);
            cmbStoresFrom.Margin = new Padding(3, 15, 3, 3);
            cmbStoresFrom.Name = "cmbStoresFrom";
            cmbStoresFrom.Size = new Size(200, 27);
            cmbStoresFrom.TabIndex = 15;
            cmbStoresFrom.SelectionChangeCommitted += cmbStoresFrom_SelectionChangeCommitted;
            // 
            // txtTotalQty
            // 
            txtTotalQty.Enabled = false;
            txtTotalQty.Location = new Point(18, 87);
            txtTotalQty.Name = "txtTotalQty";
            txtTotalQty.Size = new Size(66, 27);
            txtTotalQty.TabIndex = 9;
            txtTotalQty.Text = "0";
            txtTotalQty.KeyPress += txtTotalQty_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 91);
            label3.Name = "label3";
            label3.Size = new Size(78, 19);
            label3.TabIndex = 8;
            label3.Text = "الكمية الكلية:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(170, 87);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(159, 27);
            txtProductName.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(338, 90);
            label2.Name = "label2";
            label2.Size = new Size(71, 19);
            label2.TabIndex = 6;
            label2.Text = "اسم المنتج:";
            // 
            // txtBareCode
            // 
            txtBareCode.Location = new Point(170, 38);
            txtBareCode.Name = "txtBareCode";
            txtBareCode.Size = new Size(159, 27);
            txtBareCode.TabIndex = 3;
            txtBareCode.KeyDown += txtBareCode_KeyDown;
            txtBareCode.KeyPress += txtBareCode_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(364, 41);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 2;
            label1.Text = "باركود:";
            // 
            // AddProductDiscountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(425, 488);
            Controls.Add(groupBox1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(441, 527);
            MinimumSize = new Size(441, 527);
            Name = "AddProductDiscountForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "شاشة اضافة تخفيض على المنتجات";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtBareCode;
        private Label label1;
        private TextBox txtTotalQty;
        private Label label3;
        private TextBox txtProductName;
        private Label label2;
        private TextBox txtQtyInFrom;
        private Label label10;
        private TextBox txtQtyTransfert;
        private Label label5;
        private Label label4;
        private ComboBox cmbStoresFrom;
        private Label lblFrom;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private Button btnTransfert;
        private TextBox txtDiscountValue;
        private Label label6;
        private TextBox txtSalePrice;
        private Label label7;
    }
}