namespace Store.ApplicationUI.Gui.ProductsGui.BarcodeGui
{
    partial class BarCodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarCodeForm));
            groupBox1 = new GroupBox();
            nbrCopies = new NumericUpDown();
            label4 = new Label();
            panel1 = new Panel();
            documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            label5 = new Label();
            lblBarecode = new Label();
            lblIdProduct = new Label();
            txtPrice = new TextBox();
            txtBarCode = new TextBox();
            txtProductName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnPrint = new Button();
            btnReviewPrint = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nbrCopies).BeginInit();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nbrCopies);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblBarecode);
            groupBox1.Controls.Add(lblIdProduct);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtBarCode);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(623, 275);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "بيانات باركود المنتج";
            // 
            // nbrCopies
            // 
            nbrCopies.Location = new Point(408, 235);
            nbrCopies.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nbrCopies.Name = "nbrCopies";
            nbrCopies.Size = new Size(116, 27);
            nbrCopies.TabIndex = 11;
            nbrCopies.TextAlign = HorizontalAlignment.Center;
            nbrCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(536, 237);
            label4.Name = "label4";
            label4.Size = new Size(67, 19);
            label4.TabIndex = 10;
            label4.Text = "عدد النسخ";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(documentViewer1);
            panel1.Location = new Point(3, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 204);
            panel1.TabIndex = 8;
            // 
            // documentViewer1
            // 
            documentViewer1.Appearance.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            documentViewer1.Appearance.Options.UseFont = true;
            documentViewer1.Dock = DockStyle.Fill;
            documentViewer1.HorizontalScrollBarVisibility = DevExpress.XtraEditors.ViewInfo.ScrollBarVisibility.Hidden;
            documentViewer1.IsMetric = false;
            documentViewer1.Location = new Point(0, 0);
            documentViewer1.Name = "documentViewer1";
            documentViewer1.ShowPageMargins = false;
            documentViewer1.Size = new Size(229, 202);
            documentViewer1.TabIndex = 0;
            documentViewer1.VerticalScrollBarVisibility = DevExpress.XtraEditors.ViewInfo.ScrollBarVisibility.Hidden;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(536, 30);
            label5.Name = "label5";
            label5.Size = new Size(78, 19);
            label5.TabIndex = 7;
            label5.Text = "معرف المنتج";
            // 
            // lblBarecode
            // 
            lblBarecode.Font = new Font("Aatrix3of9Reg", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBarecode.Location = new Point(280, 184);
            lblBarecode.Margin = new Padding(10);
            lblBarecode.Name = "lblBarecode";
            lblBarecode.Size = new Size(334, 43);
            lblBarecode.TabIndex = 3;
            lblBarecode.Text = "1";
            lblBarecode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIdProduct
            // 
            lblIdProduct.AutoSize = true;
            lblIdProduct.Location = new Point(439, 30);
            lblIdProduct.Name = "lblIdProduct";
            lblIdProduct.Size = new Size(0, 19);
            lblIdProduct.TabIndex = 6;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(281, 145);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(243, 27);
            txtPrice.TabIndex = 5;
            // 
            // txtBarCode
            // 
            txtBarCode.Location = new Point(281, 106);
            txtBarCode.Name = "txtBarCode";
            txtBarCode.ReadOnly = true;
            txtBarCode.Size = new Size(243, 27);
            txtBarCode.TabIndex = 4;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(281, 62);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(243, 27);
            txtProductName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(536, 148);
            label3.Name = "label3";
            label3.Size = new Size(41, 19);
            label3.TabIndex = 2;
            label3.Text = "السعر";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(536, 109);
            label2.Name = "label2";
            label2.Size = new Size(72, 19);
            label2.TabIndex = 1;
            label2.Text = "رقم الباركود";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(536, 65);
            label1.Name = "label1";
            label1.Size = new Size(67, 19);
            label1.TabIndex = 0;
            label1.Text = "اسم المنتج";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPrint);
            groupBox2.Controls.Add(btnReviewPrint);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.Location = new Point(0, 277);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(623, 69);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "العمليات المتاحة";
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.None;
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrint.Location = new Point(73, 24);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(123, 40);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "طباعة مباشرة ";
            btnPrint.TextAlign = ContentAlignment.MiddleRight;
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnReviewPrint
            // 
            btnReviewPrint.Anchor = AnchorStyles.None;
            btnReviewPrint.Image = (Image)resources.GetObject("btnReviewPrint.Image");
            btnReviewPrint.ImageAlign = ContentAlignment.MiddleLeft;
            btnReviewPrint.Location = new Point(396, 24);
            btnReviewPrint.Name = "btnReviewPrint";
            btnReviewPrint.Size = new Size(141, 40);
            btnReviewPrint.TabIndex = 4;
            btnReviewPrint.Text = "     معاينة و طباعة";
            btnReviewPrint.UseVisualStyleBackColor = true;
            btnReviewPrint.Click += btnReviewPrint_Click;
            // 
            // BarCodeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(623, 346);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(639, 385);
            MinimizeBox = false;
            MinimumSize = new Size(639, 385);
            Name = "BarCodeForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "توليد وطباعة الباركود";
            Load += BarCodeForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nbrCopies).EndInit();
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private Button btnReviewPrint;
        private Button btnPrint;
        public TextBox txtPrice;
        public TextBox txtBarCode;
        public TextBox txtProductName;
        public Label lblBarecode;
        private Label label5;
        public Label lblIdProduct;
        private Panel panel1;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private Label label4;
        private NumericUpDown nbrCopies;
    }
}