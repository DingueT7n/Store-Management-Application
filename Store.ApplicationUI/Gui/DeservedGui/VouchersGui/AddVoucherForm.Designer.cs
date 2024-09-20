namespace Store.ApplicationUI.Gui.DeservedGui.VouchersGui
{
    partial class AddVoucherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVoucherForm));
            groupBox1 = new GroupBox();
            txtPerson = new TextBox();
            label13 = new Label();
            lblNumberD = new Label();
            label3 = new Label();
            txtNotes = new TextBox();
            Dtp = new DateTimePicker();
            label12 = new Label();
            lblUserNAme = new Label();
            txtUserName = new TextBox();
            label2 = new Label();
            txtValue = new TextBox();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            lblfromToPerson = new Label();
            rbReciptVoucher = new RadioButton();
            rbSendVoucher = new RadioButton();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddDeserved = new Button();
            btnEditDeserved = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            OperationsflowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPerson);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(lblNumberD);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNotes);
            groupBox1.Controls.Add(Dtp);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(lblUserNAme);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtValue);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(lblfromToPerson);
            groupBox1.Controls.Add(rbReciptVoucher);
            groupBox1.Controls.Add(rbSendVoucher);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(408, 432);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "انواع السندات";
            // 
            // txtPerson
            // 
            txtPerson.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPerson.Location = new Point(6, 195);
            txtPerson.Name = "txtPerson";
            txtPerson.Size = new Size(199, 27);
            txtPerson.TabIndex = 64;
            txtPerson.TextAlign = HorizontalAlignment.Center;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(324, 59);
            label13.Name = "label13";
            label13.Size = new Size(77, 19);
            label13.TabIndex = 62;
            label13.Text = "رقم العملية :";
            // 
            // lblNumberD
            // 
            lblNumberD.AutoSize = true;
            lblNumberD.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNumberD.Location = new Point(238, 59);
            lblNumberD.Name = "lblNumberD";
            lblNumberD.Size = new Size(0, 19);
            lblNumberD.TabIndex = 63;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(316, 305);
            label3.Name = "label3";
            label3.Size = new Size(86, 19);
            label3.TabIndex = 60;
            label3.Text = "سبب العملية :";
            // 
            // txtNotes
            // 
            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNotes.Location = new Point(6, 302);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(293, 109);
            txtNotes.TabIndex = 61;
            txtNotes.TextAlign = HorizontalAlignment.Center;
            // 
            // Dtp
            // 
            Dtp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Dtp.CustomFormat = "yyyy-MM-dd";
            Dtp.Format = DateTimePickerFormat.Short;
            Dtp.Location = new Point(6, 249);
            Dtp.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            Dtp.Name = "Dtp";
            Dtp.Size = new Size(199, 27);
            Dtp.TabIndex = 59;
            Dtp.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(314, 255);
            label12.Name = "label12";
            label12.Size = new Size(88, 19);
            label12.TabIndex = 58;
            label12.Text = "تاريخ العملية :";
            // 
            // lblUserNAme
            // 
            lblUserNAme.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserNAme.AutoSize = true;
            lblUserNAme.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserNAme.Location = new Point(276, 100);
            lblUserNAme.Name = "lblUserNAme";
            lblUserNAme.Size = new Size(126, 19);
            lblUserNAme.TabIndex = 48;
            lblUserNAme.Text = "المسؤول عن العملية :";
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUserName.Location = new Point(9, 97);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(199, 27);
            txtUserName.TabIndex = 49;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(325, 153);
            label2.Name = "label2";
            label2.Size = new Size(75, 19);
            label2.TabIndex = 50;
            label2.Text = "مبلغ السند :";
            // 
            // txtValue
            // 
            txtValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtValue.Location = new Point(9, 145);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(199, 27);
            txtValue.TabIndex = 51;
            txtValue.TextAlign = HorizontalAlignment.Center;
            txtValue.KeyPress += txtValue_KeyPress;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Crimson;
            label16.Location = new Point(261, 100);
            label16.Name = "label16";
            label16.Size = new Size(13, 14);
            label16.TabIndex = 57;
            label16.Text = "*";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Calibri", 9F);
            label15.ForeColor = Color.Crimson;
            label15.Location = new Point(313, 150);
            label15.Name = "label15";
            label15.Size = new Size(13, 14);
            label15.TabIndex = 56;
            label15.Text = "*";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Calibri", 9F);
            label14.ForeColor = Color.Crimson;
            label14.Location = new Point(278, 203);
            label14.Name = "label14";
            label14.Size = new Size(13, 14);
            label14.TabIndex = 55;
            label14.Text = "*";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblfromToPerson
            // 
            lblfromToPerson.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblfromToPerson.AutoSize = true;
            lblfromToPerson.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblfromToPerson.Location = new Point(303, 203);
            lblfromToPerson.Name = "lblfromToPerson";
            lblfromToPerson.Size = new Size(99, 19);
            lblfromToPerson.TabIndex = 52;
            lblfromToPerson.Text = "قبض السند من :";
            // 
            // rbReciptVoucher
            // 
            rbReciptVoucher.AutoSize = true;
            rbReciptVoucher.Checked = true;
            rbReciptVoucher.ImeMode = ImeMode.NoControl;
            rbReciptVoucher.Location = new Point(247, 19);
            rbReciptVoucher.Name = "rbReciptVoucher";
            rbReciptVoucher.Size = new Size(90, 23);
            rbReciptVoucher.TabIndex = 29;
            rbReciptVoucher.TabStop = true;
            rbReciptVoucher.Text = "سند القبض";
            rbReciptVoucher.UseVisualStyleBackColor = true;
            // 
            // rbSendVoucher
            // 
            rbSendVoucher.AutoSize = true;
            rbSendVoucher.ImeMode = ImeMode.NoControl;
            rbSendVoucher.Location = new Point(77, 19);
            rbSendVoucher.Name = "rbSendVoucher";
            rbSendVoucher.Size = new Size(91, 23);
            rbSendVoucher.TabIndex = 30;
            rbSendVoucher.Text = "سند الصرف";
            rbSendVoucher.UseVisualStyleBackColor = true;
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddDeserved);
            OperationsflowLayoutPanel.Controls.Add(btnEditDeserved);
            OperationsflowLayoutPanel.Controls.Add(button1);
            OperationsflowLayoutPanel.Dock = DockStyle.Bottom;
            OperationsflowLayoutPanel.Location = new Point(0, 432);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(408, 51);
            OperationsflowLayoutPanel.TabIndex = 33;
            // 
            // btnAddDeserved
            // 
            btnAddDeserved.Anchor = AnchorStyles.None;
            btnAddDeserved.Image = (Image)resources.GetObject("btnAddDeserved.Image");
            btnAddDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddDeserved.Location = new Point(305, 3);
            btnAddDeserved.Name = "btnAddDeserved";
            btnAddDeserved.Size = new Size(100, 40);
            btnAddDeserved.TabIndex = 3;
            btnAddDeserved.Text = "   اضافة";
            btnAddDeserved.UseVisualStyleBackColor = true;
            btnAddDeserved.Click += btnAddDeserved_Click;
            // 
            // btnEditDeserved
            // 
            btnEditDeserved.Anchor = AnchorStyles.None;
            btnEditDeserved.Image = (Image)resources.GetObject("btnEditDeserved.Image");
            btnEditDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditDeserved.Location = new Point(199, 3);
            btnEditDeserved.Name = "btnEditDeserved";
            btnEditDeserved.Size = new Size(100, 40);
            btnEditDeserved.TabIndex = 4;
            btnEditDeserved.Text = "   تعديل";
            btnEditDeserved.UseVisualStyleBackColor = true;
            btnEditDeserved.Visible = false;
            btnEditDeserved.Click += btnEditDeserved_Click;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(93, 3);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 7;
            button1.Text = "      الخروج";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddVoucherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(408, 483);
            Controls.Add(OperationsflowLayoutPanel);
            Controls.Add(groupBox1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddVoucherForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة سند";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            OperationsflowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbReciptVoucher;
        private RadioButton rbSendVoucher;
        private Label lblNumberD;
        private Label label13;
        private Label label3;
        private TextBox txtNotes;
        private DateTimePicker Dtp;
        private Label label12;
        private Label lblUserNAme;
        private TextBox txtUserName;
        private Label label2;
        private TextBox txtValue;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label lblfromToPerson;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddDeserved;
        private Button btnEditDeserved;
        private Button button1;
        private TextBox txtPerson;
    }
}