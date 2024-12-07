namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeSalaryGui
{
    partial class EmployeeSalaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeSalaryForm));
            gbInfo = new GroupBox();
            txtNetSalary = new TextBox();
            label6 = new Label();
            txtNotes = new TextBox();
            label4 = new Label();
            txtBorrows = new TextBox();
            label3 = new Label();
            txtAllSalary = new TextBox();
            label1 = new Label();
            dtpReminderDate = new DateTimePicker();
            label2 = new Label();
            dtpJoined = new DateTimePicker();
            label5 = new Label();
            cmbEmployees = new ComboBox();
            label12 = new Label();
            btnAdd = new Button();
            gbInfo.SuspendLayout();
            SuspendLayout();
            // 
            // gbInfo
            // 
            gbInfo.Controls.Add(txtNetSalary);
            gbInfo.Controls.Add(label6);
            gbInfo.Controls.Add(txtNotes);
            gbInfo.Controls.Add(label4);
            gbInfo.Controls.Add(txtBorrows);
            gbInfo.Controls.Add(label3);
            gbInfo.Controls.Add(txtAllSalary);
            gbInfo.Controls.Add(label1);
            gbInfo.Controls.Add(dtpReminderDate);
            gbInfo.Controls.Add(label2);
            gbInfo.Controls.Add(dtpJoined);
            gbInfo.Controls.Add(label5);
            gbInfo.Controls.Add(cmbEmployees);
            gbInfo.Controls.Add(label12);
            gbInfo.Controls.Add(btnAdd);
            gbInfo.Dock = DockStyle.Fill;
            gbInfo.Location = new Point(0, 0);
            gbInfo.Name = "gbInfo";
            gbInfo.Size = new Size(653, 308);
            gbInfo.TabIndex = 0;
            gbInfo.TabStop = false;
            gbInfo.Text = "اذن الصرف لـ";
            // 
            // txtNetSalary
            // 
            txtNetSalary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNetSalary.Enabled = false;
            txtNetSalary.Location = new Point(298, 178);
            txtNetSalary.Name = "txtNetSalary";
            txtNetSalary.Size = new Size(219, 27);
            txtNetSalary.TabIndex = 58;
            txtNetSalary.TextAlign = HorizontalAlignment.Center;
            txtNetSalary.KeyPress += txtAllSalary_KeyPress;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(567, 186);
            label6.Name = "label6";
            label6.Size = new Size(80, 19);
            label6.TabIndex = 57;
            label6.Text = "صافي المرتب:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(14, 150);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(175, 91);
            txtNotes.TabIndex = 56;
            txtNotes.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(195, 141);
            label4.Name = "label4";
            label4.Size = new Size(72, 19);
            label4.TabIndex = 55;
            label4.Text = "الملاحظات:";
            // 
            // txtBorrows
            // 
            txtBorrows.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBorrows.Enabled = false;
            txtBorrows.Location = new Point(298, 133);
            txtBorrows.Name = "txtBorrows";
            txtBorrows.Size = new Size(219, 27);
            txtBorrows.TabIndex = 54;
            txtBorrows.TextAlign = HorizontalAlignment.Center;
            txtBorrows.KeyPress += txtAllSalary_KeyPress;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(526, 133);
            label3.Name = "label3";
            label3.Size = new Size(121, 19);
            label3.TabIndex = 53;
            label3.Text = "المسحوبات والسلف:";
            // 
            // txtAllSalary
            // 
            txtAllSalary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAllSalary.Location = new Point(298, 90);
            txtAllSalary.Name = "txtAllSalary";
            txtAllSalary.Size = new Size(219, 27);
            txtAllSalary.TabIndex = 52;
            txtAllSalary.TextAlign = HorizontalAlignment.Center;
            txtAllSalary.KeyPress += txtAllSalary_KeyPress;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(561, 93);
            label1.Name = "label1";
            label1.Size = new Size(86, 19);
            label1.TabIndex = 51;
            label1.Text = "المرتب الكامل:";
            // 
            // dtpReminderDate
            // 
            dtpReminderDate.Format = DateTimePickerFormat.Short;
            dtpReminderDate.Location = new Point(14, 95);
            dtpReminderDate.Name = "dtpReminderDate";
            dtpReminderDate.Size = new Size(121, 27);
            dtpReminderDate.TabIndex = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(140, 98);
            label2.Name = "label2";
            label2.Size = new Size(131, 19);
            label2.TabIndex = 49;
            label2.Text = "تاريخ الاستقاق القادم:";
            // 
            // dtpJoined
            // 
            dtpJoined.Format = DateTimePickerFormat.Short;
            dtpJoined.Location = new Point(14, 46);
            dtpJoined.Name = "dtpJoined";
            dtpJoined.Size = new Size(121, 27);
            dtpJoined.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(164, 50);
            label5.Name = "label5";
            label5.Size = new Size(107, 19);
            label5.TabIndex = 47;
            label5.Text = "تاريخ اذن الصرف:";
            // 
            // cmbEmployees
            // 
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(298, 46);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(219, 27);
            cmbEmployees.TabIndex = 46;
            cmbEmployees.SelectionChangeCommitted += cmbEmployees_SelectionChangeCommitted;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(563, 49);
            label12.Name = "label12";
            label12.Size = new Size(84, 19);
            label12.TabIndex = 45;
            label12.Text = "اختر الموظف:";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(235, 262);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(172, 40);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "حفظ العملية";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // EmployeeSalaryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(653, 308);
            Controls.Add(gbInfo);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(669, 347);
            MinimizeBox = false;
            MinimumSize = new Size(669, 347);
            Name = "EmployeeSalaryForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "صرف مرتبات الموظفين";
            gbInfo.ResumeLayout(false);
            gbInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbInfo;
        private Button btnAdd;
        private ComboBox cmbEmployees;
        private Label label12;
        private DateTimePicker dtpReminderDate;
        private Label label2;
        private DateTimePicker dtpJoined;
        private Label label5;
        private TextBox txtBorrows;
        private Label label3;
        private TextBox txtAllSalary;
        private Label label1;
        private TextBox txtNotes;
        private Label label4;
        private TextBox txtNetSalary;
        private Label label6;
    }
}