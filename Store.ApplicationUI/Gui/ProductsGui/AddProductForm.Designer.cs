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
            cbFavorite = new CheckBox();
            label1 = new Label();
            txtNameProduct = new TextBox();
            label2 = new Label();
            txtBarCode = new TextBox();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
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
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddProduct = new Button();
            btnEditProduct = new Button();
            btnPrintBarCode = new Button();
            GbInfoProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbImageProduct).BeginInit();
            OperationsflowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GbInfoProduct
            // 
            GbInfoProduct.Controls.Add(cbFavorite);
            GbInfoProduct.Controls.Add(label1);
            GbInfoProduct.Controls.Add(txtNameProduct);
            GbInfoProduct.Controls.Add(label2);
            GbInfoProduct.Controls.Add(txtBarCode);
            GbInfoProduct.Controls.Add(label16);
            GbInfoProduct.Controls.Add(label15);
            GbInfoProduct.Controls.Add(label14);
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
            resources.ApplyResources(GbInfoProduct, "GbInfoProduct");
            GbInfoProduct.Name = "GbInfoProduct";
            GbInfoProduct.TabStop = false;
            // 
            // cbFavorite
            // 
            resources.ApplyResources(cbFavorite, "cbFavorite");
            cbFavorite.Name = "cbFavorite";
            cbFavorite.UseVisualStyleBackColor = true;
            cbFavorite.CheckedChanged += cbFavorite_CheckedChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // txtNameProduct
            // 
            resources.ApplyResources(txtNameProduct, "txtNameProduct");
            txtNameProduct.Name = "txtNameProduct";
            txtNameProduct.TextChanged += txtNameProduct_TextChanged;
            txtNameProduct.KeyDown += txtNameProduct_KeyDown;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // txtBarCode
            // 
            resources.ApplyResources(txtBarCode, "txtBarCode");
            txtBarCode.Name = "txtBarCode";
            txtBarCode.TextChanged += txtBarCode_TextChanged;
            txtBarCode.KeyDown += txtNameProduct_KeyDown;
            txtBarCode.KeyPress += txtBarCode_KeyPress;
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.BackColor = Color.Transparent;
            label16.ForeColor = Color.Crimson;
            label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.BackColor = Color.Transparent;
            label15.ForeColor = Color.Crimson;
            label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.BackColor = Color.Transparent;
            label14.ForeColor = Color.Crimson;
            label14.Name = "label14";
            // 
            // lblProductId
            // 
            resources.ApplyResources(lblProductId, "lblProductId");
            lblProductId.Name = "lblProductId";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            // 
            // DtpExperation
            // 
            resources.ApplyResources(DtpExperation, "DtpExperation");
            DtpExperation.Format = DateTimePickerFormat.Short;
            DtpExperation.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            DtpExperation.Name = "DtpExperation";
            DtpExperation.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // PbImageProduct
            // 
            resources.ApplyResources(PbImageProduct, "PbImageProduct");
            PbImageProduct.Name = "PbImageProduct";
            PbImageProduct.TabStop = false;
            PbImageProduct.Click += PbImageProduct_Click;
            // 
            // txtBuyPrice
            // 
            resources.ApplyResources(txtBuyPrice, "txtBuyPrice");
            txtBuyPrice.Name = "txtBuyPrice";
            txtBuyPrice.KeyDown += txtNameProduct_KeyDown;
            txtBuyPrice.KeyPress += txtBuyPrice_KeyPress;
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // txtTotalQty
            // 
            resources.ApplyResources(txtTotalQty, "txtTotalQty");
            txtTotalQty.Name = "txtTotalQty";
            txtTotalQty.KeyDown += txtNameProduct_KeyDown;
            txtTotalQty.KeyPress += txtTotalQty_KeyPress;
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // txtSaleAfterTax
            // 
            resources.ApplyResources(txtSaleAfterTax, "txtSaleAfterTax");
            txtSaleAfterTax.Name = "txtSaleAfterTax";
            txtSaleAfterTax.KeyDown += txtNameProduct_KeyDown;
            txtSaleAfterTax.KeyPress += txtSaleAfterTax_KeyPress;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // txtDiscountAllowed
            // 
            resources.ApplyResources(txtDiscountAllowed, "txtDiscountAllowed");
            txtDiscountAllowed.Name = "txtDiscountAllowed";
            txtDiscountAllowed.KeyDown += txtNameProduct_KeyDown;
            txtDiscountAllowed.KeyPress += txtDiscountAllowed_KeyPress;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // txtSalePrice
            // 
            resources.ApplyResources(txtSalePrice, "txtSalePrice");
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.KeyDown += txtNameProduct_KeyDown;
            txtSalePrice.KeyPress += txtSalePrice_KeyPress;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // txtWholeSalePrice
            // 
            resources.ApplyResources(txtWholeSalePrice, "txtWholeSalePrice");
            txtWholeSalePrice.Name = "txtWholeSalePrice";
            txtWholeSalePrice.KeyDown += txtNameProduct_KeyDown;
            txtWholeSalePrice.KeyPress += txtWholeSalePrice_KeyPress;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // btnAddCategory
            // 
            resources.ApplyResources(btnAddCategory, "btnAddCategory");
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // txtTaxValue
            // 
            resources.ApplyResources(txtTaxValue, "txtTaxValue");
            txtTaxValue.Name = "txtTaxValue";
            txtTaxValue.KeyDown += txtNameProduct_KeyDown;
            txtTaxValue.KeyPress += txtTaxValue_KeyPress;
            // 
            // CbIsTaxed
            // 
            resources.ApplyResources(CbIsTaxed, "CbIsTaxed");
            CbIsTaxed.Name = "CbIsTaxed";
            CbIsTaxed.UseVisualStyleBackColor = true;
            CbIsTaxed.CheckedChanged += CbIsTaxed_CheckedChanged;
            // 
            // CMBCategory
            // 
            resources.ApplyResources(CMBCategory, "CMBCategory");
            CMBCategory.FormattingEnabled = true;
            CMBCategory.Name = "CMBCategory";
            CMBCategory.KeyDown += txtNameProduct_KeyDown;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // txtMinQty
            // 
            resources.ApplyResources(txtMinQty, "txtMinQty");
            txtMinQty.Name = "txtMinQty";
            txtMinQty.KeyDown += txtNameProduct_KeyDown;
            txtMinQty.KeyPress += txtMinQty_KeyPress;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // OperationsflowLayoutPanel
            // 
            resources.ApplyResources(OperationsflowLayoutPanel, "OperationsflowLayoutPanel");
            OperationsflowLayoutPanel.Controls.Add(btnAddProduct);
            OperationsflowLayoutPanel.Controls.Add(btnEditProduct);
            OperationsflowLayoutPanel.Controls.Add(btnPrintBarCode);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            // 
            // btnAddProduct
            // 
            resources.ApplyResources(btnAddProduct, "btnAddProduct");
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnEditProduct
            // 
            resources.ApplyResources(btnEditProduct, "btnEditProduct");
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.UseVisualStyleBackColor = true;
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnPrintBarCode
            // 
            resources.ApplyResources(btnPrintBarCode, "btnPrintBarCode");
            btnPrintBarCode.Name = "btnPrintBarCode";
            btnPrintBarCode.UseVisualStyleBackColor = true;
            btnPrintBarCode.Click += btnPrintBarCode_Click;
            // 
            // AddProductForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(OperationsflowLayoutPanel);
            Controls.Add(GbInfoProduct);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProductForm";
            ShowIcon = false;
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
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddProduct;
        private Button btnEditProduct;
        private Button btnPrintBarCode;
        private Label lblProductId;
        private Label label13;
        private DateTimePicker DtpExperation;
        private Label label12;
        private Label label11;
        private PictureBox PbImageProduct;
        private TextBox txtBuyPrice;
        private Label label10;
        private TextBox txtTotalQty;
        private Label label9;
        private TextBox txtSaleAfterTax;
        private Label label8;
        private TextBox txtDiscountAllowed;
        private Label label7;
        private TextBox txtSalePrice;
        private Label label5;
        private TextBox txtWholeSalePrice;
        private Label label6;
        private Button btnAddCategory;
        private TextBox txtTaxValue;
        private CheckBox CbIsTaxed;
        private ComboBox CMBCategory;
        private Label label4;
        private TextBox txtMinQty;
        private Label label3;
        private TextBox txtBarCode;
        private Label label2;
        private Label label14;
        private Label label16;
        private Label label15;
        private CheckBox cbFavorite;
    }
}