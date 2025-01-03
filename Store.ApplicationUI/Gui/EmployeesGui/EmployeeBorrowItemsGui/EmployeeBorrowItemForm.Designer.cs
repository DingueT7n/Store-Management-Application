namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowItemsGui
{
    partial class EmployeeBorrowItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeBorrowItemForm));
            btnAdd = new Button();
            gbInfoEmployee = new GroupBox();
            cmbEmployees = new ComboBox();
            dtpJoined = new DateTimePicker();
            label5 = new Label();
            label12 = new Label();
            txtQty = new TextBox();
            label9 = new Label();
            txtProductName = new TextBox();
            label3 = new Label();
            txtBareCode = new TextBox();
            label1 = new Label();
            gbInfoEmployee.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(192, 181);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(172, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "حفظ العملية";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // gbInfoEmployee
            // 
            gbInfoEmployee.Controls.Add(btnAdd);
            gbInfoEmployee.Controls.Add(cmbEmployees);
            gbInfoEmployee.Controls.Add(dtpJoined);
            gbInfoEmployee.Controls.Add(label5);
            gbInfoEmployee.Controls.Add(label12);
            gbInfoEmployee.Controls.Add(txtQty);
            gbInfoEmployee.Controls.Add(label9);
            gbInfoEmployee.Controls.Add(txtProductName);
            gbInfoEmployee.Controls.Add(label3);
            gbInfoEmployee.Controls.Add(txtBareCode);
            gbInfoEmployee.Controls.Add(label1);
            gbInfoEmployee.Dock = DockStyle.Fill;
            gbInfoEmployee.Location = new Point(0, 0);
            gbInfoEmployee.Name = "gbInfoEmployee";
            gbInfoEmployee.Size = new Size(590, 233);
            gbInfoEmployee.TabIndex = 12;
            gbInfoEmployee.TabStop = false;
            gbInfoEmployee.Text = "بيانات العملية";
            // 
            // cmbEmployees
            // 
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(269, 132);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(217, 27);
            cmbEmployees.TabIndex = 44;
            // 
            // dtpJoined
            // 
            dtpJoined.Format = DateTimePickerFormat.Short;
            dtpJoined.Location = new Point(10, 47);
            dtpJoined.Name = "dtpJoined";
            dtpJoined.Size = new Size(121, 27);
            dtpJoined.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(152, 51);
            label5.Name = "label5";
            label5.Size = new Size(89, 19);
            label5.TabIndex = 42;
            label5.Text = "تاريخ السحب:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(500, 135);
            label12.Name = "label12";
            label12.Size = new Size(84, 19);
            label12.TabIndex = 37;
            label12.Text = "اختر الموظف:";
            // 
            // txtQty
            // 
            txtQty.Location = new Point(10, 91);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(121, 27);
            txtQty.TabIndex = 36;
            txtQty.TextAlign = HorizontalAlignment.Center;
            txtQty.KeyPress += txtBareCode_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(140, 94);
            label9.Name = "label9";
            label9.Size = new Size(101, 19);
            label9.TabIndex = 35;
            label9.Text = "الكمية المسحوبة:";
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductName.Enabled = false;
            txtProductName.Location = new Point(269, 87);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(217, 27);
            txtProductName.TabIndex = 33;
            txtProductName.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(513, 90);
            label3.Name = "label3";
            label3.Size = new Size(71, 19);
            label3.TabIndex = 32;
            label3.Text = "اسم المنتج:";
            // 
            // txtBareCode
            // 
            txtBareCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBareCode.Location = new Point(268, 43);
            txtBareCode.Name = "txtBareCode";
            txtBareCode.Size = new Size(219, 27);
            txtBareCode.TabIndex = 31;
            txtBareCode.TextAlign = HorizontalAlignment.Center;
            txtBareCode.KeyDown += txtBareCode_KeyDown;
            txtBareCode.KeyPress += txtBareCode_KeyPress;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(538, 46);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 28;
            label1.Text = "باركود:";
            // 
            // EmployeeBorrowItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(590, 233);
            Controls.Add(gbInfoEmployee);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(606, 272);
            MinimizeBox = false;
            MinimumSize = new Size(606, 272);
            Name = "EmployeeBorrowItemForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "المسحوبات من الموظف";
            gbInfoEmployee.ResumeLayout(false);
            gbInfoEmployee.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAdd;
        private GroupBox gbInfoEmployee;
        private DateTimePicker dtpJoined;
        private Label label5;
        private Label label12;
        private TextBox txtQty;
        private Label label9;
        private TextBox txtSalary;
        private TextBox txtProductName;
        private Label label3;
        private TextBox txtBareCode;
        private Label label1;
        private ComboBox cmbEmployees;
    }
}