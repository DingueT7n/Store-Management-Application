namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.TransferBetweenStoresGui
{
    partial class StoreTransfertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreTransfertForm));
            groupBox1 = new GroupBox();
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
            groupBox2 = new GroupBox();
            label6 = new Label();
            cmbStoreTo = new ComboBox();
            groupBox3 = new GroupBox();
            btnTransfert = new Button();
            txtReason = new TextBox();
            label9 = new Label();
            txtMaker = new TextBox();
            label8 = new Label();
            label7 = new Label();
            dateTimePicker1 = new DateTimePicker();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
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
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(404, 256);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "المخزن المحول منه";
            // 
            // txtQtyInFrom
            // 
            txtQtyInFrom.Enabled = false;
            txtQtyInFrom.Location = new Point(116, 171);
            txtQtyInFrom.Name = "txtQtyInFrom";
            txtQtyInFrom.Size = new Size(66, 27);
            txtQtyInFrom.TabIndex = 14;
            txtQtyInFrom.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(200, 174);
            label10.Name = "label10";
            label10.Size = new Size(195, 19);
            label10.TabIndex = 13;
            label10.Text = "الكمية الموجودة في المخزن المحدد";
            // 
            // txtQtyTransfert
            // 
            txtQtyTransfert.Location = new Point(236, 213);
            txtQtyTransfert.Name = "txtQtyTransfert";
            txtQtyTransfert.Size = new Size(62, 27);
            txtQtyTransfert.TabIndex = 12;
            txtQtyTransfert.Text = "0";
            txtQtyTransfert.KeyPress += textBox4_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(304, 221);
            label5.Name = "label5";
            label5.Size = new Size(91, 19);
            label5.TabIndex = 11;
            label5.Text = "الكمية المحولة:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(278, 134);
            label4.Name = "label4";
            label4.Size = new Size(117, 19);
            label4.TabIndex = 10;
            label4.Text = "المخزن المحول منه:";
            // 
            // cmbStoresFrom
            // 
            cmbStoresFrom.FormattingEnabled = true;
            cmbStoresFrom.Location = new Point(9, 131);
            cmbStoresFrom.Margin = new Padding(3, 15, 3, 3);
            cmbStoresFrom.Name = "cmbStoresFrom";
            cmbStoresFrom.Size = new Size(263, 27);
            cmbStoresFrom.TabIndex = 9;
            // 
            // txtTotalQty
            // 
            txtTotalQty.Enabled = false;
            txtTotalQty.Location = new Point(3, 84);
            txtTotalQty.Name = "txtTotalQty";
            txtTotalQty.Size = new Size(66, 27);
            txtTotalQty.TabIndex = 5;
            txtTotalQty.Text = "0";
            txtTotalQty.KeyPress += textBox3_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 88);
            label3.Name = "label3";
            label3.Size = new Size(78, 19);
            label3.TabIndex = 4;
            label3.Text = "الكمية الكلية:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(155, 84);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(159, 27);
            txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(323, 87);
            label2.Name = "label2";
            label2.Size = new Size(71, 19);
            label2.TabIndex = 2;
            label2.Text = "اسم المنتج:";
            // 
            // txtBareCode
            // 
            txtBareCode.Location = new Point(155, 38);
            txtBareCode.Name = "txtBareCode";
            txtBareCode.Size = new Size(159, 27);
            txtBareCode.TabIndex = 1;
            txtBareCode.KeyDown += txtBareCode_KeyDown;
            txtBareCode.KeyPress += textBox1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(349, 41);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 0;
            label1.Text = "باركود:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cmbStoreTo);
            groupBox2.Location = new Point(12, 274);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(401, 97);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "المخزن المحول له";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(281, 37);
            label6.Name = "label6";
            label6.Size = new Size(110, 19);
            label6.TabIndex = 12;
            label6.Text = "المخزن المحول له:";
            // 
            // cmbStoreTo
            // 
            cmbStoreTo.FormattingEnabled = true;
            cmbStoreTo.Location = new Point(6, 35);
            cmbStoreTo.Margin = new Padding(3, 15, 3, 3);
            cmbStoreTo.Name = "cmbStoreTo";
            cmbStoreTo.Size = new Size(263, 27);
            cmbStoreTo.TabIndex = 11;
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
            groupBox3.Location = new Point(419, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(232, 359);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "بيانات العملية";
            // 
            // btnTransfert
            // 
            btnTransfert.Anchor = AnchorStyles.None;
            btnTransfert.Image = (Image)resources.GetObject("btnTransfert.Image");
            btnTransfert.ImageAlign = ContentAlignment.MiddleLeft;
            btnTransfert.ImeMode = ImeMode.NoControl;
            btnTransfert.Location = new Point(6, 313);
            btnTransfert.Name = "btnTransfert";
            btnTransfert.Size = new Size(208, 40);
            btnTransfert.TabIndex = 19;
            btnTransfert.Text = "اتمام العملية";
            btnTransfert.UseVisualStyleBackColor = true;
            btnTransfert.Click += btnExportCustomer_Click;
            // 
            // txtReason
            // 
            txtReason.Location = new Point(6, 205);
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(220, 77);
            txtReason.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(140, 183);
            label9.Name = "label9";
            label9.Size = new Size(86, 19);
            label9.TabIndex = 17;
            label9.Text = "سبب التحويل:";
            // 
            // txtMaker
            // 
            txtMaker.Location = new Point(6, 148);
            txtMaker.Name = "txtMaker";
            txtMaker.Size = new Size(220, 27);
            txtMaker.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(100, 126);
            label8.Name = "label8";
            label8.Size = new Size(126, 19);
            label8.TabIndex = 15;
            label8.Text = "المسؤول عن التحويل:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(175, 65);
            label7.Name = "label7";
            label7.Size = new Size(51, 19);
            label7.TabIndex = 14;
            label7.Text = "التاريخ:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(24, 61);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(145, 27);
            dateTimePicker1.TabIndex = 13;
            // 
            // StoreTransfertForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(663, 383);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(679, 422);
            MinimizeBox = false;
            MinimumSize = new Size(679, 422);
            Name = "StoreTransfertForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "نقل المنتجات بين المخازن";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private TextBox txtBareCode;
        private TextBox txtTotalQty;
        private Label label3;
        private TextBox txtProductName;
        private Label label2;
        private Label label4;
        private ComboBox cmbStoresFrom;
        private TextBox txtQtyTransfert;
        private Label label5;
        private Label label6;
        private ComboBox cmbStoreTo;
        private Label label7;
        private DateTimePicker dateTimePicker1;
        private TextBox txtMaker;
        private Label label8;
        private TextBox txtReason;
        private Label label9;
        private Button btnTransfert;
        private TextBox txtQtyInFrom;
        private Label label10;
    }
}