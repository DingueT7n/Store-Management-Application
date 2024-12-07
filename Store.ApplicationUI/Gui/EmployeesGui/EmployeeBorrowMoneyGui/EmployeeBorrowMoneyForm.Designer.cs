namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowMoneyGui
{
    partial class EmployeeBorrowMoneyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeBorrowMoneyForm));
            gbInfoEmployee = new GroupBox();
            txtNotes = new TextBox();
            label4 = new Label();
            rbEmployee = new RadioButton();
            rbNormalPerson = new RadioButton();
            dtpReminderDate = new DateTimePicker();
            label2 = new Label();
            btnAdd = new Button();
            cmbEmployees = new ComboBox();
            dtpJoined = new DateTimePicker();
            label5 = new Label();
            label12 = new Label();
            txtPrice = new TextBox();
            label9 = new Label();
            txtNameDebtGiver = new TextBox();
            label3 = new Label();
            txtPersonName = new TextBox();
            label1 = new Label();
            gbInfoEmployee.SuspendLayout();
            SuspendLayout();
            // 
            // gbInfoEmployee
            // 
            gbInfoEmployee.Controls.Add(txtNotes);
            gbInfoEmployee.Controls.Add(label4);
            gbInfoEmployee.Controls.Add(rbEmployee);
            gbInfoEmployee.Controls.Add(rbNormalPerson);
            gbInfoEmployee.Controls.Add(dtpReminderDate);
            gbInfoEmployee.Controls.Add(label2);
            gbInfoEmployee.Controls.Add(btnAdd);
            gbInfoEmployee.Controls.Add(cmbEmployees);
            gbInfoEmployee.Controls.Add(dtpJoined);
            gbInfoEmployee.Controls.Add(label5);
            gbInfoEmployee.Controls.Add(label12);
            gbInfoEmployee.Controls.Add(txtPrice);
            gbInfoEmployee.Controls.Add(label9);
            gbInfoEmployee.Controls.Add(txtNameDebtGiver);
            gbInfoEmployee.Controls.Add(label3);
            gbInfoEmployee.Controls.Add(txtPersonName);
            gbInfoEmployee.Controls.Add(label1);
            gbInfoEmployee.Dock = DockStyle.Fill;
            gbInfoEmployee.Location = new Point(0, 0);
            gbInfoEmployee.Name = "gbInfoEmployee";
            gbInfoEmployee.Size = new Size(602, 306);
            gbInfoEmployee.TabIndex = 13;
            gbInfoEmployee.TabStop = false;
            gbInfoEmployee.Text = "بيانات العملية";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(12, 190);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(175, 72);
            txtNotes.TabIndex = 50;
            txtNotes.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(193, 190);
            label4.Name = "label4";
            label4.Size = new Size(72, 19);
            label4.TabIndex = 49;
            label4.Text = "الملاحظات:";
            // 
            // rbEmployee
            // 
            rbEmployee.AutoSize = true;
            rbEmployee.Location = new Point(330, 26);
            rbEmployee.Name = "rbEmployee";
            rbEmployee.Size = new Size(64, 23);
            rbEmployee.TabIndex = 48;
            rbEmployee.Text = "موظف";
            rbEmployee.UseVisualStyleBackColor = true;
            rbEmployee.CheckedChanged += rbEmployee_CheckedChanged;
            // 
            // rbNormalPerson
            // 
            rbNormalPerson.AutoSize = true;
            rbNormalPerson.Checked = true;
            rbNormalPerson.Location = new Point(429, 26);
            rbNormalPerson.Name = "rbNormalPerson";
            rbNormalPerson.Size = new Size(98, 23);
            rbNormalPerson.TabIndex = 47;
            rbNormalPerson.TabStop = true;
            rbNormalPerson.Text = "شخص عادي";
            rbNormalPerson.UseVisualStyleBackColor = true;
            rbNormalPerson.CheckedChanged += rbNormalPerson_CheckedChanged;
            // 
            // dtpReminderDate
            // 
            dtpReminderDate.Format = DateTimePickerFormat.Short;
            dtpReminderDate.Location = new Point(30, 108);
            dtpReminderDate.Name = "dtpReminderDate";
            dtpReminderDate.Size = new Size(121, 27);
            dtpReminderDate.TabIndex = 46;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(160, 114);
            label2.Name = "label2";
            label2.Size = new Size(105, 19);
            label2.TabIndex = 45;
            label2.Text = "تاريخ الاستحقاق:";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(221, 254);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(172, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "حفظ العملية";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbEmployees
            // 
            cmbEmployees.Enabled = false;
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(287, 109);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(219, 27);
            cmbEmployees.TabIndex = 44;
            // 
            // dtpJoined
            // 
            dtpJoined.Format = DateTimePickerFormat.Short;
            dtpJoined.Location = new Point(30, 61);
            dtpJoined.Name = "dtpJoined";
            dtpJoined.Size = new Size(121, 27);
            dtpJoined.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(182, 64);
            label5.Name = "label5";
            label5.Size = new Size(83, 19);
            label5.TabIndex = 42;
            label5.Text = "تاريخ السلف:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(511, 117);
            label12.Name = "label12";
            label12.Size = new Size(84, 19);
            label12.TabIndex = 37;
            label12.Text = "اختر الموظف:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(30, 148);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(121, 27);
            txtPrice.TabIndex = 36;
            txtPrice.TextAlign = HorizontalAlignment.Center;
            txtPrice.KeyPress += txtPrice_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(221, 151);
            label9.Name = "label9";
            label9.Size = new Size(44, 19);
            label9.TabIndex = 35;
            label9.Text = "المبلغ:";
            // 
            // txtNameDebtGiver
            // 
            txtNameDebtGiver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNameDebtGiver.Location = new Point(288, 154);
            txtNameDebtGiver.Name = "txtNameDebtGiver";
            txtNameDebtGiver.Size = new Size(219, 27);
            txtNameDebtGiver.TabIndex = 33;
            txtNameDebtGiver.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(526, 162);
            label3.Name = "label3";
            label3.Size = new Size(69, 19);
            label3.TabIndex = 32;
            label3.Text = "اسم الدائن:";
            // 
            // txtPersonName
            // 
            txtPersonName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPersonName.Location = new Point(288, 64);
            txtPersonName.Name = "txtPersonName";
            txtPersonName.Size = new Size(219, 27);
            txtPersonName.TabIndex = 31;
            txtPersonName.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(513, 67);
            label1.Name = "label1";
            label1.Size = new Size(83, 19);
            label1.TabIndex = 28;
            label1.Text = "اسم الشخص:";
            // 
            // EmployeeBorrowMoneyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(602, 306);
            Controls.Add(gbInfoEmployee);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(618, 345);
            MinimizeBox = false;
            MinimumSize = new Size(618, 345);
            Name = "EmployeeBorrowMoneyForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "السلفيات للموظفين او الأشخاص";
            gbInfoEmployee.ResumeLayout(false);
            gbInfoEmployee.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbInfoEmployee;
        private Button btnAdd;
        private ComboBox cmbEmployees;
        private DateTimePicker dtpJoined;
        private Label label5;
        private Label label12;
        private TextBox txtPrice;
        private Label label9;
        private TextBox txtNameDebtGiver;
        private Label label3;
        private TextBox txtPersonName;
        private Label label1;
        private DateTimePicker dtpReminderDate;
        private Label label2;
        private RadioButton rbEmployee;
        private RadioButton rbNormalPerson;
        private TextBox txtNotes;
        private Label label4;
    }
}