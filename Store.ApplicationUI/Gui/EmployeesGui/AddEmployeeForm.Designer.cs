namespace Store.ApplicationUI.Gui.EmployeesGui
{
    partial class AddEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeeForm));
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAdd = new Button();
            btnEdit = new Button();
            gbInfoEmployee = new GroupBox();
            dtpJoined = new DateTimePicker();
            label5 = new Label();
            txtAddress = new TextBox();
            label4 = new Label();
            lblِCustomerId = new Label();
            label13 = new Label();
            label12 = new Label();
            txtEmail = new TextBox();
            label9 = new Label();
            txtSalary = new TextBox();
            txtPhoneNumber = new TextBox();
            label3 = new Label();
            txtNbrCartId = new TextBox();
            label2 = new Label();
            txtNameEmployee = new TextBox();
            label1 = new Label();
            OperationsflowLayoutPanel.SuspendLayout();
            gbInfoEmployee.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAdd);
            OperationsflowLayoutPanel.Controls.Add(btnEdit);
            OperationsflowLayoutPanel.Dock = DockStyle.Bottom;
            OperationsflowLayoutPanel.Location = new Point(0, 233);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(707, 51);
            OperationsflowLayoutPanel.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(604, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "   اضافة";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(498, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 40);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "   تعديل";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Visible = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // gbInfoEmployee
            // 
            gbInfoEmployee.Controls.Add(dtpJoined);
            gbInfoEmployee.Controls.Add(label5);
            gbInfoEmployee.Controls.Add(txtAddress);
            gbInfoEmployee.Controls.Add(label4);
            gbInfoEmployee.Controls.Add(lblِCustomerId);
            gbInfoEmployee.Controls.Add(label13);
            gbInfoEmployee.Controls.Add(label12);
            gbInfoEmployee.Controls.Add(txtEmail);
            gbInfoEmployee.Controls.Add(label9);
            gbInfoEmployee.Controls.Add(txtSalary);
            gbInfoEmployee.Controls.Add(txtPhoneNumber);
            gbInfoEmployee.Controls.Add(label3);
            gbInfoEmployee.Controls.Add(txtNbrCartId);
            gbInfoEmployee.Controls.Add(label2);
            gbInfoEmployee.Controls.Add(txtNameEmployee);
            gbInfoEmployee.Controls.Add(label1);
            gbInfoEmployee.Dock = DockStyle.Fill;
            gbInfoEmployee.Location = new Point(0, 0);
            gbInfoEmployee.Name = "gbInfoEmployee";
            gbInfoEmployee.Size = new Size(707, 233);
            gbInfoEmployee.TabIndex = 11;
            gbInfoEmployee.TabStop = false;
            gbInfoEmployee.Text = "بيانات الموظف";
            gbInfoEmployee.Enter += gbInfoEmployee_Enter;
            // 
            // dtpJoined
            // 
            dtpJoined.Format = DateTimePickerFormat.Short;
            dtpJoined.Location = new Point(483, 147);
            dtpJoined.Name = "dtpJoined";
            dtpJoined.Size = new Size(121, 27);
            dtpJoined.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(610, 153);
            label5.Name = "label5";
            label5.Size = new Size(89, 19);
            label5.TabIndex = 42;
            label5.Text = "تاريخ الانضمام";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(24, 108);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(219, 27);
            txtAddress.TabIndex = 41;
            txtAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(248, 112);
            label4.Name = "label4";
            label4.Size = new Size(94, 19);
            label4.TabIndex = 40;
            label4.Text = "عنوان الموظف:";
            // 
            // lblِCustomerId
            // 
            lblِCustomerId.AutoSize = true;
            lblِCustomerId.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblِCustomerId.Location = new Point(112, 153);
            lblِCustomerId.Name = "lblِCustomerId";
            lblِCustomerId.Size = new Size(41, 19);
            lblِCustomerId.TabIndex = 39;
            lblِCustomerId.Text = "0000";
            lblِCustomerId.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(248, 153);
            label13.Name = "label13";
            label13.Size = new Size(94, 19);
            label13.TabIndex = 38;
            label13.Text = "معرف الموظف:";
            label13.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(647, 71);
            label12.Name = "label12";
            label12.Size = new Size(46, 19);
            label12.TabIndex = 37;
            label12.Text = "الراتب:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(24, 67);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(219, 27);
            txtEmail.TabIndex = 36;
            txtEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(248, 71);
            label9.Name = "label9";
            label9.Size = new Size(94, 19);
            label9.TabIndex = 35;
            label9.Text = "البريد الالكتروني:";
            // 
            // txtSalary
            // 
            txtSalary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSalary.Location = new Point(390, 67);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(217, 27);
            txtSalary.TabIndex = 34;
            txtSalary.Text = "0";
            txtSalary.TextAlign = HorizontalAlignment.Center;
            txtSalary.KeyPress += txtSalary_KeyPress;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPhoneNumber.Location = new Point(390, 108);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(217, 27);
            txtPhoneNumber.TabIndex = 33;
            txtPhoneNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(624, 112);
            label3.Name = "label3";
            label3.Size = new Size(71, 19);
            label3.TabIndex = 32;
            label3.Text = "رقم الهاتف:";
            // 
            // txtNbrCartId
            // 
            txtNbrCartId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNbrCartId.Location = new Point(24, 26);
            txtNbrCartId.Name = "txtNbrCartId";
            txtNbrCartId.Size = new Size(219, 27);
            txtNbrCartId.TabIndex = 31;
            txtNbrCartId.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(248, 29);
            label2.Name = "label2";
            label2.Size = new Size(105, 19);
            label2.TabIndex = 30;
            label2.Text = "رقم بطاقة تعريف:";
            // 
            // txtNameEmployee
            // 
            txtNameEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNameEmployee.Location = new Point(390, 26);
            txtNameEmployee.Name = "txtNameEmployee";
            txtNameEmployee.Size = new Size(219, 27);
            txtNameEmployee.TabIndex = 29;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(616, 29);
            label1.Name = "label1";
            label1.Size = new Size(83, 19);
            label1.TabIndex = 28;
            label1.Text = "اسم الموظف:";
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(707, 284);
            Controls.Add(gbInfoEmployee);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(723, 323);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            MinimumSize = new Size(723, 323);
            Name = "AddEmployeeForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "اضافة/تعديل موظف";
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbInfoEmployee.ResumeLayout(false);
            gbInfoEmployee.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAdd;
        private Button btnEdit;
        private GroupBox gbInfoEmployee;
        private Label lblِCustomerId;
        private Label label13;
        private Label label12;
        private TextBox txtEmail;
        private Label label9;
        private TextBox txtSalary;
        private TextBox txtPhoneNumber;
        private Label label3;
        private TextBox txtNbrCartId;
        private Label label2;
        private TextBox txtNameEmployee;
        private Label label1;
        private TextBox txtAddress;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpJoined;
    }
}