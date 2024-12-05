namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreDeleteDamagedProductGui
{
    partial class StoreDamagedProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreDamagedProductForm));
            groupBox3 = new GroupBox();
            btnTransfert = new Button();
            txtReason = new TextBox();
            label9 = new Label();
            txtMaker = new TextBox();
            label8 = new Label();
            label7 = new Label();
            dateTimePicker1 = new DateTimePicker();
            gbProductInfo = new GroupBox();
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
            groupBox3.SuspendLayout();
            gbProductInfo.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnTransfert);
            groupBox3.Controls.Add(txtReason);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtMaker);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(dateTimePicker1);
            groupBox3.Dock = DockStyle.Right;
            groupBox3.Location = new Point(435, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(242, 322);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "بيانات العملية";
            // 
            // btnTransfert
            // 
            btnTransfert.Anchor = AnchorStyles.None;
            btnTransfert.Image = (Image)resources.GetObject("btnTransfert.Image");
            btnTransfert.ImageAlign = ContentAlignment.MiddleLeft;
            btnTransfert.ImeMode = ImeMode.NoControl;
            btnTransfert.Location = new Point(17, 270);
            btnTransfert.Name = "btnTransfert";
            btnTransfert.Size = new Size(208, 40);
            btnTransfert.TabIndex = 19;
            btnTransfert.Text = "اتمام العملية";
            btnTransfert.UseVisualStyleBackColor = true;
            btnTransfert.Click += btnTransfert_Click;
            // 
            // txtReason
            // 
            txtReason.Location = new Point(6, 181);
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(220, 77);
            txtReason.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(140, 159);
            label9.Name = "label9";
            label9.Size = new Size(83, 19);
            label9.TabIndex = 17;
            label9.Text = "سبب الاخراج:";
            // 
            // txtMaker
            // 
            txtMaker.Location = new Point(6, 124);
            txtMaker.Name = "txtMaker";
            txtMaker.Size = new Size(220, 27);
            txtMaker.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(100, 102);
            label8.Name = "label8";
            label8.Size = new Size(123, 19);
            label8.TabIndex = 15;
            label8.Text = "المسؤول عن الاخراج:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(175, 41);
            label7.Name = "label7";
            label7.Size = new Size(51, 19);
            label7.TabIndex = 14;
            label7.Text = "التاريخ:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(24, 37);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(145, 27);
            dateTimePicker1.TabIndex = 13;
            // 
            // gbProductInfo
            // 
            gbProductInfo.Controls.Add(txtQtyInFrom);
            gbProductInfo.Controls.Add(label10);
            gbProductInfo.Controls.Add(txtQtyTransfert);
            gbProductInfo.Controls.Add(label5);
            gbProductInfo.Controls.Add(label4);
            gbProductInfo.Controls.Add(cmbStoresFrom);
            gbProductInfo.Controls.Add(txtTotalQty);
            gbProductInfo.Controls.Add(label3);
            gbProductInfo.Controls.Add(txtProductName);
            gbProductInfo.Controls.Add(label2);
            gbProductInfo.Controls.Add(txtBareCode);
            gbProductInfo.Controls.Add(label1);
            gbProductInfo.Dock = DockStyle.Left;
            gbProductInfo.Location = new Point(0, 0);
            gbProductInfo.Name = "gbProductInfo";
            gbProductInfo.Size = new Size(429, 322);
            gbProductInfo.TabIndex = 3;
            gbProductInfo.TabStop = false;
            gbProductInfo.Text = "بيانات المنتج";
            // 
            // txtQtyInFrom
            // 
            txtQtyInFrom.Enabled = false;
            txtQtyInFrom.Location = new Point(136, 171);
            txtQtyInFrom.Name = "txtQtyInFrom";
            txtQtyInFrom.Size = new Size(66, 27);
            txtQtyInFrom.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(215, 175);
            label10.Name = "label10";
            label10.Size = new Size(199, 19);
            label10.TabIndex = 13;
            label10.Text = "الكمية الموجودة في المخزن المحدد:";
            // 
            // txtQtyTransfert
            // 
            txtQtyTransfert.Location = new Point(136, 213);
            txtQtyTransfert.Name = "txtQtyTransfert";
            txtQtyTransfert.Size = new Size(66, 27);
            txtQtyTransfert.TabIndex = 12;
            txtQtyTransfert.KeyPress += txtBareCode_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(271, 221);
            label5.Name = "label5";
            label5.Size = new Size(143, 19);
            label5.TabIndex = 11;
            label5.Text = "الكمية المخرجة (التالفة):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(363, 132);
            label4.Name = "label4";
            label4.Size = new Size(51, 19);
            label4.TabIndex = 10;
            label4.Text = "المخزن:";
            // 
            // cmbStoresFrom
            // 
            cmbStoresFrom.FormattingEnabled = true;
            cmbStoresFrom.Location = new Point(90, 129);
            cmbStoresFrom.Margin = new Padding(3, 15, 3, 3);
            cmbStoresFrom.Name = "cmbStoresFrom";
            cmbStoresFrom.Size = new Size(244, 27);
            cmbStoresFrom.TabIndex = 9;
            // 
            // txtTotalQty
            // 
            txtTotalQty.Enabled = false;
            txtTotalQty.Location = new Point(23, 84);
            txtTotalQty.Name = "txtTotalQty";
            txtTotalQty.Size = new Size(66, 27);
            txtTotalQty.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 88);
            label3.Name = "label3";
            label3.Size = new Size(78, 19);
            label3.TabIndex = 4;
            label3.Text = "الكمية الكلية:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(175, 84);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(159, 27);
            txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(343, 87);
            label2.Name = "label2";
            label2.Size = new Size(71, 19);
            label2.TabIndex = 2;
            label2.Text = "اسم المنتج:";
            // 
            // txtBareCode
            // 
            txtBareCode.Location = new Point(175, 38);
            txtBareCode.Name = "txtBareCode";
            txtBareCode.Size = new Size(159, 27);
            txtBareCode.TabIndex = 1;
            txtBareCode.KeyDown += txtBareCode_KeyDown;
            txtBareCode.KeyPress += txtBareCode_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(369, 41);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 0;
            label1.Text = "باركود:";
            // 
            // StoreDamagedProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(677, 322);
            Controls.Add(groupBox3);
            Controls.Add(gbProductInfo);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StoreDamagedProductForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اخراج المنتجات التالفة من المخزن";
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbProductInfo.ResumeLayout(false);
            gbProductInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private Button btnTransfert;
        private TextBox txtReason;
        private Label label9;
        private TextBox txtMaker;
        private Label label8;
        private Label label7;
        private DateTimePicker dateTimePicker1;
        private GroupBox gbProductInfo;
        private TextBox txtQtyInFrom;
        private Label label10;
        private TextBox txtQtyTransfert;
        private Label label5;
        private Label label4;
        private ComboBox cmbStoresFrom;
        private TextBox txtTotalQty;
        private Label label3;
        private TextBox txtProductName;
        private Label label2;
        private TextBox txtBareCode;
        private Label label1;
    }
}