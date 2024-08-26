namespace Store.ApplicationUI.Gui.ProductsGui
{
    partial class AddSupplierForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupplierForm));
            GbInfoProduct = new GroupBox();
            lblِSupplierId = new Label();
            label13 = new Label();
            label12 = new Label();
            txtNotes = new TextBox();
            label9 = new Label();
            txtMaxDebtAllowed = new TextBox();
            txtPhoneNumber = new TextBox();
            label3 = new Label();
            txtAddress = new TextBox();
            label2 = new Label();
            txtNameSupplier = new TextBox();
            label1 = new Label();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddSupplier = new Button();
            btnEditSupplier = new Button();
            button1 = new Button();
            GbInfoProduct.SuspendLayout();
            OperationsflowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GbInfoProduct
            // 
            GbInfoProduct.Controls.Add(lblِSupplierId);
            GbInfoProduct.Controls.Add(label13);
            GbInfoProduct.Controls.Add(label12);
            GbInfoProduct.Controls.Add(txtNotes);
            GbInfoProduct.Controls.Add(label9);
            GbInfoProduct.Controls.Add(txtMaxDebtAllowed);
            GbInfoProduct.Controls.Add(txtPhoneNumber);
            GbInfoProduct.Controls.Add(label3);
            GbInfoProduct.Controls.Add(txtAddress);
            GbInfoProduct.Controls.Add(label2);
            GbInfoProduct.Controls.Add(txtNameSupplier);
            GbInfoProduct.Controls.Add(label1);
            GbInfoProduct.Dock = DockStyle.Fill;
            GbInfoProduct.Location = new Point(0, 0);
            GbInfoProduct.Name = "GbInfoProduct";
            GbInfoProduct.Size = new Size(707, 284);
            GbInfoProduct.TabIndex = 0;
            GbInfoProduct.TabStop = false;
            GbInfoProduct.Text = "بيانات المورد";
            // 
            // lblِSupplierId
            // 
            lblِSupplierId.AutoSize = true;
            lblِSupplierId.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblِSupplierId.Location = new Point(467, 163);
            lblِSupplierId.Name = "lblِSupplierId";
            lblِSupplierId.Size = new Size(41, 19);
            lblِSupplierId.TabIndex = 27;
            lblِSupplierId.Text = "0000";
            lblِSupplierId.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(595, 163);
            label13.Name = "label13";
            label13.Size = new Size(82, 19);
            label13.TabIndex = 26;
            label13.Text = "معرف المورد:";
            label13.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(231, 33);
            label12.Name = "label12";
            label12.Size = new Size(118, 19);
            label12.TabIndex = 24;
            label12.Text = "اعلى دين مسموح به:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(8, 94);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(217, 73);
            txtNotes.TabIndex = 19;
            txtNotes.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(231, 78);
            label9.Name = "label9";
            label9.Size = new Size(64, 19);
            label9.TabIndex = 18;
            label9.Text = "ملاحظات:";
            // 
            // txtMaxDebtAllowed
            // 
            txtMaxDebtAllowed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtMaxDebtAllowed.Location = new Point(8, 29);
            txtMaxDebtAllowed.Name = "txtMaxDebtAllowed";
            txtMaxDebtAllowed.Size = new Size(217, 27);
            txtMaxDebtAllowed.TabIndex = 9;
            txtMaxDebtAllowed.Text = "0";
            txtMaxDebtAllowed.TextAlign = HorizontalAlignment.Center;
            txtMaxDebtAllowed.KeyPress += txtTaxValue_KeyPress;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPhoneNumber.Location = new Point(368, 117);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(217, 27);
            txtPhoneNumber.TabIndex = 5;
            txtPhoneNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(595, 122);
            label3.Name = "label3";
            label3.Size = new Size(71, 19);
            label3.TabIndex = 4;
            label3.Text = "رقم الهاتف:";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAddress.Location = new Point(368, 74);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(219, 27);
            txtAddress.TabIndex = 3;
            txtAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(595, 78);
            label2.Name = "label2";
            label2.Size = new Size(82, 19);
            label2.TabIndex = 2;
            label2.Text = "عنوان المورد:";
            // 
            // txtNameSupplier
            // 
            txtNameSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNameSupplier.Location = new Point(368, 33);
            txtNameSupplier.Name = "txtNameSupplier";
            txtNameSupplier.Size = new Size(219, 27);
            txtNameSupplier.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(600, 36);
            label1.Name = "label1";
            label1.Size = new Size(71, 19);
            label1.TabIndex = 0;
            label1.Text = "اسم المورد:";
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddSupplier);
            OperationsflowLayoutPanel.Controls.Add(btnEditSupplier);
            OperationsflowLayoutPanel.Controls.Add(button1);
            OperationsflowLayoutPanel.Dock = DockStyle.Bottom;
            OperationsflowLayoutPanel.Location = new Point(0, 233);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(707, 51);
            OperationsflowLayoutPanel.TabIndex = 9;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Anchor = AnchorStyles.None;
            btnAddSupplier.Image = (Image)resources.GetObject("btnAddSupplier.Image");
            btnAddSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddSupplier.Location = new Point(604, 3);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(100, 40);
            btnAddSupplier.TabIndex = 3;
            btnAddSupplier.Text = "   اضافة";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddProduct_Click;
            // 
            // btnEditSupplier
            // 
            btnEditSupplier.Anchor = AnchorStyles.None;
            btnEditSupplier.Image = (Image)resources.GetObject("btnEditSupplier.Image");
            btnEditSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditSupplier.Location = new Point(498, 3);
            btnEditSupplier.Name = "btnEditSupplier";
            btnEditSupplier.Size = new Size(100, 40);
            btnEditSupplier.TabIndex = 4;
            btnEditSupplier.Text = "   تعديل";
            btnEditSupplier.UseVisualStyleBackColor = true;
            btnEditSupplier.Visible = false;
            btnEditSupplier.Click += btnEditProduct_Click;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(392, 3);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 7;
            button1.Text = "      الخروج";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddSupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(707, 284);
            Controls.Add(OperationsflowLayoutPanel);
            Controls.Add(GbInfoProduct);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(723, 323);
            MinimizeBox = false;
            MinimumSize = new Size(723, 323);
            Name = "AddSupplierForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة/تعديل مورد ";
            GbInfoProduct.ResumeLayout(false);
            GbInfoProduct.PerformLayout();
            OperationsflowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GbInfoProduct;
        private Label label1;
        private TextBox txtNameSupplier;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddSupplier;
        private Button btnEditSupplier;
        private Button button1;
        private Label lblِSupplierId;
        private Label label13;
        private Label label12;
        private TextBox txtNotes;
        private Label label9;
        private TextBox txtMaxDebtAllowed;
        private TextBox txtPhoneNumber;
        private Label label3;
        private TextBox txtAddress;
        private Label label2;
    }
}