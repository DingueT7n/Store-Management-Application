namespace Store.ApplicationUI.Gui.ProductsGui
{
    partial class AddProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductForm));
            GbInfoProduct = new GroupBox();
            lblProductId = new Label();
            label13 = new Label();
            DtpExperation = new DateTimePicker();
            label12 = new Label();
            label11 = new Label();
            PbImageProduct = new PictureBox();
            txtBuyPrice = new TextBox();
            label10 = new Label();
            txtTotalQty = new TextBox();
            label9 = new Label();
            txtSaleAfterTax = new TextBox();
            label8 = new Label();
            txtDiscountAllowed = new TextBox();
            label7 = new Label();
            txtSalePrice = new TextBox();
            label5 = new Label();
            txtWholeSalePrice = new TextBox();
            label6 = new Label();
            btnAddCategory = new Button();
            txtTaxValue = new TextBox();
            CbIsTaxed = new CheckBox();
            CMBCategory = new ComboBox();
            label4 = new Label();
            txtMinQty = new TextBox();
            label3 = new Label();
            txtBarCode = new TextBox();
            label2 = new Label();
            txtNameProduct = new TextBox();
            label1 = new Label();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddProduct = new Button();
            btnEditProduct = new Button();
            btnPrintBarCode = new Button();
            button1 = new Button();
            GbInfoProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbImageProduct).BeginInit();
            OperationsflowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GbInfoProduct
            // 
            GbInfoProduct.Controls.Add(lblProductId);
            GbInfoProduct.Controls.Add(label13);
            GbInfoProduct.Controls.Add(DtpExperation);
            GbInfoProduct.Controls.Add(label12);
            GbInfoProduct.Controls.Add(label11);
            GbInfoProduct.Controls.Add(PbImageProduct);
            GbInfoProduct.Controls.Add(txtBuyPrice);
            GbInfoProduct.Controls.Add(label10);
            GbInfoProduct.Controls.Add(txtTotalQty);
            GbInfoProduct.Controls.Add(label9);
            GbInfoProduct.Controls.Add(txtSaleAfterTax);
            GbInfoProduct.Controls.Add(label8);
            GbInfoProduct.Controls.Add(txtDiscountAllowed);
            GbInfoProduct.Controls.Add(label7);
            GbInfoProduct.Controls.Add(txtSalePrice);
            GbInfoProduct.Controls.Add(label5);
            GbInfoProduct.Controls.Add(txtWholeSalePrice);
            GbInfoProduct.Controls.Add(label6);
            GbInfoProduct.Controls.Add(btnAddCategory);
            GbInfoProduct.Controls.Add(txtTaxValue);
            GbInfoProduct.Controls.Add(CbIsTaxed);
            GbInfoProduct.Controls.Add(CMBCategory);
            GbInfoProduct.Controls.Add(label4);
            GbInfoProduct.Controls.Add(txtMinQty);
            GbInfoProduct.Controls.Add(label3);
            GbInfoProduct.Controls.Add(txtBarCode);
            GbInfoProduct.Controls.Add(label2);
            GbInfoProduct.Controls.Add(txtNameProduct);
            GbInfoProduct.Controls.Add(label1);
            GbInfoProduct.Location = new Point(12, 12);
            GbInfoProduct.Name = "GbInfoProduct";
            GbInfoProduct.Size = new Size(683, 400);
            GbInfoProduct.TabIndex = 0;
            GbInfoProduct.TabStop = false;
            GbInfoProduct.Text = "بيانات المنتج";
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductId.Location = new Point(114, 289);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(0, 19);
            lblProductId.TabIndex = 27;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(189, 289);
            label13.Name = "label13";
            label13.Size = new Size(82, 19);
            label13.TabIndex = 26;
            label13.Text = "معرف المنتج:";
            // 
            // DtpExperation
            // 
            DtpExperation.CustomFormat = "yyyy-MM-dd";
            DtpExperation.Format = DateTimePickerFormat.Short;
            DtpExperation.Location = new Point(63, 243);
            DtpExperation.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            DtpExperation.Name = "DtpExperation";
            DtpExperation.Size = new Size(119, 27);
            DtpExperation.TabIndex = 25;
            DtpExperation.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(189, 247);
            label12.Name = "label12";
            label12.Size = new Size(128, 19);
            label12.TabIndex = 24;
            label12.Text = "تاريخ انتهاء الصلاحية:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(591, 289);
            label11.Name = "label11";
            label11.Size = new Size(80, 19);
            label11.TabIndex = 23;
            label11.Text = "صورة المنتج:";
            // 
            // PbImageProduct
            // 
            PbImageProduct.Image = (Image)resources.GetObject("PbImageProduct.Image");
            PbImageProduct.Location = new Point(368, 289);
            PbImageProduct.Name = "PbImageProduct";
            PbImageProduct.Size = new Size(217, 105);
            PbImageProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            PbImageProduct.TabIndex = 22;
            PbImageProduct.TabStop = false;
            // 
            // txtBuyPrice
            // 
            txtBuyPrice.Location = new Point(368, 240);
            txtBuyPrice.Name = "txtBuyPrice";
            txtBuyPrice.Size = new Size(217, 27);
            txtBuyPrice.TabIndex = 21;
            txtBuyPrice.TextAlign = HorizontalAlignment.Center;
            txtBuyPrice.KeyPress += txtBuyPrice_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(600, 243);
            label10.Name = "label10";
            label10.Size = new Size(71, 19);
            label10.TabIndex = 20;
            label10.Text = "سعر الشراء:";
            // 
            // txtTotalQty
            // 
            txtTotalQty.Location = new Point(2, 29);
            txtTotalQty.Name = "txtTotalQty";
            txtTotalQty.Size = new Size(180, 27);
            txtTotalQty.TabIndex = 19;
            txtTotalQty.TextAlign = HorizontalAlignment.Center;
            txtTotalQty.KeyPress += txtTotalQty_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(188, 33);
            label9.Name = "label9";
            label9.Size = new Size(97, 19);
            label9.TabIndex = 18;
            label9.Text = "الكمية الاجمالية:";
            // 
            // txtSaleAfterTax
            // 
            txtSaleAfterTax.Location = new Point(2, 199);
            txtSaleAfterTax.Name = "txtSaleAfterTax";
            txtSaleAfterTax.Size = new Size(183, 27);
            txtSaleAfterTax.TabIndex = 17;
            txtSaleAfterTax.TextAlign = HorizontalAlignment.Center;
            txtSaleAfterTax.KeyPress += txtSaleAfterTax_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(188, 203);
            label8.Name = "label8";
            label8.Size = new Size(144, 19);
            label8.TabIndex = 16;
            label8.Text = "سعر التجزئة بعد الضريبة:";
            // 
            // txtDiscountAllowed
            // 
            txtDiscountAllowed.Location = new Point(2, 155);
            txtDiscountAllowed.Name = "txtDiscountAllowed";
            txtDiscountAllowed.Size = new Size(183, 27);
            txtDiscountAllowed.TabIndex = 15;
            txtDiscountAllowed.TextAlign = HorizontalAlignment.Center;
            txtDiscountAllowed.KeyPress += txtDiscountAllowed_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(188, 159);
            label7.Name = "label7";
            label7.Size = new Size(101, 19);
            label7.TabIndex = 14;
            label7.Text = "الخصم المسموح:";
            // 
            // txtSalePrice
            // 
            txtSalePrice.Location = new Point(2, 116);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(183, 27);
            txtSalePrice.TabIndex = 13;
            txtSalePrice.TextAlign = HorizontalAlignment.Center;
            txtSalePrice.KeyPress += txtSalePrice_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(188, 120);
            label5.Name = "label5";
            label5.Size = new Size(99, 19);
            label5.TabIndex = 12;
            label5.Text = "سعر بيع التجزئة:";
            // 
            // txtWholeSalePrice
            // 
            txtWholeSalePrice.Location = new Point(2, 75);
            txtWholeSalePrice.Name = "txtWholeSalePrice";
            txtWholeSalePrice.Size = new Size(182, 27);
            txtWholeSalePrice.TabIndex = 11;
            txtWholeSalePrice.TextAlign = HorizontalAlignment.Center;
            txtWholeSalePrice.KeyPress += txtWholeSalePrice_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(188, 78);
            label6.Name = "label6";
            label6.Size = new Size(89, 19);
            label6.TabIndex = 10;
            label6.Text = "سعر بيع جملة:";
            // 
            // btnAddCategory
            // 
            btnAddCategory.Image = (Image)resources.GetObject("btnAddCategory.Image");
            btnAddCategory.Location = new Point(368, 114);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(34, 35);
            btnAddCategory.TabIndex = 8;
            btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // txtTaxValue
            // 
            txtTaxValue.Location = new Point(368, 201);
            txtTaxValue.Name = "txtTaxValue";
            txtTaxValue.Size = new Size(71, 27);
            txtTaxValue.TabIndex = 9;
            txtTaxValue.Text = "0";
            txtTaxValue.TextAlign = HorizontalAlignment.Center;
            txtTaxValue.KeyPress += txtTaxValue_KeyPress;
            // 
            // CbIsTaxed
            // 
            CbIsTaxed.AutoSize = true;
            CbIsTaxed.Location = new Point(466, 203);
            CbIsTaxed.Name = "CbIsTaxed";
            CbIsTaxed.Size = new Size(205, 23);
            CbIsTaxed.TabIndex = 8;
            CbIsTaxed.Text = "خاضع لضريبة القيمة المضافة %:\r\n";
            CbIsTaxed.UseVisualStyleBackColor = true;
            // 
            // CMBCategory
            // 
            CMBCategory.FormattingEnabled = true;
            CMBCategory.Location = new Point(406, 117);
            CMBCategory.Name = "CMBCategory";
            CMBCategory.Size = new Size(179, 27);
            CMBCategory.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(620, 120);
            label4.Name = "label4";
            label4.Size = new Size(51, 19);
            label4.TabIndex = 6;
            label4.Text = "الصنف:";
            // 
            // txtMinQty
            // 
            txtMinQty.Location = new Point(406, 159);
            txtMinQty.Name = "txtMinQty";
            txtMinQty.Size = new Size(143, 27);
            txtMinQty.TabIndex = 5;
            txtMinQty.TextAlign = HorizontalAlignment.Center;
            txtMinQty.KeyPress += txtMinQty_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(563, 163);
            label3.Name = "label3";
            label3.Size = new Size(108, 19);
            label3.TabIndex = 4;
            label3.Text = "الحد الادنى للكمية:";
            // 
            // txtBarCode
            // 
            txtBarCode.Location = new Point(368, 74);
            txtBarCode.Name = "txtBarCode";
            txtBarCode.Size = new Size(219, 27);
            txtBarCode.TabIndex = 3;
            txtBarCode.TextAlign = HorizontalAlignment.Center;
            txtBarCode.KeyPress += txtBarCode_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(595, 78);
            label2.Name = "label2";
            label2.Size = new Size(76, 19);
            label2.TabIndex = 2;
            label2.Text = "رقم الباركود:";
            // 
            // txtNameProduct
            // 
            txtNameProduct.Location = new Point(368, 33);
            txtNameProduct.Name = "txtNameProduct";
            txtNameProduct.Size = new Size(219, 27);
            txtNameProduct.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(600, 36);
            label1.Name = "label1";
            label1.Size = new Size(71, 19);
            label1.TabIndex = 0;
            label1.Text = "اسم المنتج:";
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddProduct);
            OperationsflowLayoutPanel.Controls.Add(btnEditProduct);
            OperationsflowLayoutPanel.Controls.Add(btnPrintBarCode);
            OperationsflowLayoutPanel.Controls.Add(button1);
            OperationsflowLayoutPanel.Dock = DockStyle.Bottom;
            OperationsflowLayoutPanel.Location = new Point(0, 430);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(707, 51);
            OperationsflowLayoutPanel.TabIndex = 9;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.None;
            btnAddProduct.Image = (Image)resources.GetObject("btnAddProduct.Image");
            btnAddProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddProduct.Location = new Point(604, 3);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(100, 40);
            btnAddProduct.TabIndex = 3;
            btnAddProduct.Text = "   اضافة";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnEditProduct
            // 
            btnEditProduct.Anchor = AnchorStyles.None;
            btnEditProduct.Image = (Image)resources.GetObject("btnEditProduct.Image");
            btnEditProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditProduct.Location = new Point(498, 3);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(100, 40);
            btnEditProduct.TabIndex = 4;
            btnEditProduct.Text = "   تعديل";
            btnEditProduct.UseVisualStyleBackColor = true;
            btnEditProduct.Visible = false;
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnPrintBarCode
            // 
            btnPrintBarCode.Anchor = AnchorStyles.None;
            btnPrintBarCode.Image = (Image)resources.GetObject("btnPrintBarCode.Image");
            btnPrintBarCode.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrintBarCode.Location = new Point(376, 3);
            btnPrintBarCode.Name = "btnPrintBarCode";
            btnPrintBarCode.Size = new Size(116, 40);
            btnPrintBarCode.TabIndex = 6;
            btnPrintBarCode.Text = "      طباعة باركود";
            btnPrintBarCode.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(270, 3);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 7;
            button1.Text = "      الخروج";
            button1.UseVisualStyleBackColor = true;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(707, 481);
            Controls.Add(OperationsflowLayoutPanel);
            Controls.Add(GbInfoProduct);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MinimizeBox = false;
            MinimumSize = new Size(723, 520);
            Name = "AddProductForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة/تعديل منتج ";
            GbInfoProduct.ResumeLayout(false);
            GbInfoProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbImageProduct).EndInit();
            OperationsflowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GbInfoProduct;
        private Label label1;
        private TextBox txtNameProduct;
        private TextBox txtMinQty;
        private Label label3;
        private TextBox txtBarCode;
        private Label label2;
        private CheckBox CbIsTaxed;
        private ComboBox CMBCategory;
        private Label label4;
        private TextBox txtTaxValue;
        private Button btnAddCategory;
        private TextBox txtSalePrice;
        private Label label5;
        private TextBox txtWholeSalePrice;
        private Label label6;
        private TextBox txtDiscountAllowed;
        private Label label7;
        private TextBox txtSaleAfterTax;
        private Label label8;
        private TextBox txtTotalQty;
        private Label label9;
        private TextBox txtBuyPrice;
        private Label label10;
        private Label label11;
        private PictureBox PbImageProduct;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddProduct;
        private Button btnEditProduct;
        private Button btnPrintBarCode;
        private Label label12;
        private Button button1;
        private DateTimePicker DtpExperation;
        private Label lblProductId;
        private Label label13;
    }
}