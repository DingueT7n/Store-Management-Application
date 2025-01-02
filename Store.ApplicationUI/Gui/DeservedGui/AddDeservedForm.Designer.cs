namespace Store.ApplicationUI.Gui.DeservedGui
{
    partial class AddDeservedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDeservedForm));
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddDeserved = new Button();
            btnEditDeserved = new Button();
            groupBox1 = new GroupBox();
            lblDeservedID = new Label();
            label13 = new Label();
            label3 = new Label();
            txtNotes = new TextBox();
            DtpExperation = new DateTimePicker();
            label12 = new Label();
            lblUserNAme = new Label();
            txtUserName = new TextBox();
            label2 = new Label();
            txtValueDeserved = new TextBox();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            btnAddTypes = new Button();
            CMBType = new ComboBox();
            label4 = new Label();
            OperationsflowLayoutPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddDeserved);
            OperationsflowLayoutPanel.Controls.Add(btnEditDeserved);
            OperationsflowLayoutPanel.Dock = DockStyle.Bottom;
            OperationsflowLayoutPanel.Location = new Point(0, 436);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(410, 51);
            OperationsflowLayoutPanel.TabIndex = 10;
            // 
            // btnAddDeserved
            // 
            btnAddDeserved.Anchor = AnchorStyles.None;
            btnAddDeserved.Image = (Image)resources.GetObject("btnAddDeserved.Image");
            btnAddDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddDeserved.Location = new Point(307, 3);
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
            btnEditDeserved.Location = new Point(201, 3);
            btnEditDeserved.Name = "btnEditDeserved";
            btnEditDeserved.Size = new Size(100, 40);
            btnEditDeserved.TabIndex = 4;
            btnEditDeserved.Text = "   تعديل";
            btnEditDeserved.UseVisualStyleBackColor = true;
            btnEditDeserved.Visible = false;
            btnEditDeserved.Click += btnEditDeserved_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDeservedID);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNotes);
            groupBox1.Controls.Add(DtpExperation);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(lblUserNAme);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtValueDeserved);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(btnAddTypes);
            groupBox1.Controls.Add(CMBType);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(410, 436);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "بيانات المصروفة";
            // 
            // lblDeservedID
            // 
            lblDeservedID.AutoSize = true;
            lblDeservedID.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeservedID.Location = new Point(246, 384);
            lblDeservedID.Name = "lblDeservedID";
            lblDeservedID.Size = new Size(0, 19);
            lblDeservedID.TabIndex = 47;
            lblDeservedID.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(299, 384);
            label13.Name = "label13";
            label13.Size = new Size(104, 19);
            label13.TabIndex = 46;
            label13.Text = "معرف المصروفة :";
            label13.Visible = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(327, 253);
            label3.Name = "label3";
            label3.Size = new Size(62, 19);
            label3.TabIndex = 44;
            label3.Text = "الملاحظة:";
            // 
            // txtNotes
            // 
            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNotes.Location = new Point(26, 249);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(293, 109);
            txtNotes.TabIndex = 45;
            txtNotes.TextAlign = HorizontalAlignment.Center;
            // 
            // DtpExperation
            // 
            DtpExperation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DtpExperation.CustomFormat = "yyyy-MM-dd";
            DtpExperation.Format = DateTimePickerFormat.Short;
            DtpExperation.Location = new Point(46, 202);
            DtpExperation.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            DtpExperation.Name = "DtpExperation";
            DtpExperation.Size = new Size(164, 27);
            DtpExperation.TabIndex = 43;
            DtpExperation.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(301, 210);
            label12.Name = "label12";
            label12.Size = new Size(102, 19);
            label12.TabIndex = 42;
            label12.Text = "تاريخ المصروفة :";
            // 
            // lblUserNAme
            // 
            lblUserNAme.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserNAme.AutoSize = true;
            lblUserNAme.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserNAme.Location = new Point(227, 47);
            lblUserNAme.Name = "lblUserNAme";
            lblUserNAme.Size = new Size(177, 19);
            lblUserNAme.TabIndex = 32;
            lblUserNAme.Text = "المسؤول عن ادخال المصروفة :";
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUserName.Location = new Point(11, 44);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(199, 27);
            txtUserName.TabIndex = 33;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(306, 99);
            label2.Name = "label2";
            label2.Size = new Size(97, 19);
            label2.TabIndex = 34;
            label2.Text = "قيمة المصروفة :";
            // 
            // txtValueDeserved
            // 
            txtValueDeserved.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtValueDeserved.Location = new Point(6, 92);
            txtValueDeserved.Name = "txtValueDeserved";
            txtValueDeserved.Size = new Size(204, 27);
            txtValueDeserved.TabIndex = 35;
            txtValueDeserved.TextAlign = HorizontalAlignment.Center;
            txtValueDeserved.KeyPress += txtValueDeserved_KeyPress;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Crimson;
            label16.Location = new Point(212, 47);
            label16.Name = "label16";
            label16.Size = new Size(13, 14);
            label16.TabIndex = 41;
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
            label15.Location = new Point(299, 99);
            label15.Name = "label15";
            label15.Size = new Size(13, 14);
            label15.TabIndex = 40;
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
            label14.Location = new Point(304, 148);
            label14.Name = "label14";
            label14.Size = new Size(13, 14);
            label14.TabIndex = 39;
            label14.Text = "*";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddTypes
            // 
            btnAddTypes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddTypes.Image = (Image)resources.GetObject("btnAddTypes.Image");
            btnAddTypes.Location = new Point(8, 145);
            btnAddTypes.Name = "btnAddTypes";
            btnAddTypes.Size = new Size(34, 32);
            btnAddTypes.TabIndex = 38;
            btnAddTypes.UseVisualStyleBackColor = true;
            btnAddTypes.Click += btnAddTypes_Click;
            // 
            // CMBType
            // 
            CMBType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CMBType.FormattingEnabled = true;
            CMBType.Location = new Point(46, 148);
            CMBType.Name = "CMBType";
            CMBType.Size = new Size(164, 27);
            CMBType.TabIndex = 37;
            CMBType.Text = "اختر النوع";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(315, 152);
            label4.Name = "label4";
            label4.Size = new Size(89, 19);
            label4.TabIndex = 36;
            label4.Text = "نوع المصروفة :";
            // 
            // AddDeservedForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(410, 487);
            Controls.Add(groupBox1);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddDeservedForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة مصروفة";
            OperationsflowLayoutPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddDeserved;
        private Button btnEditDeserved;
        private GroupBox groupBox1;
        private Label lblUserNAme;
        private TextBox txtUserName;
        private Label label2;
        private TextBox txtValueDeserved;
        private Label label16;
        private Label label15;
        private Label label14;
        private Button btnAddTypes;
        private ComboBox CMBType;
        private Label label4;
        private DateTimePicker DtpExperation;
        private Label label12;
        private Label label3;
        private TextBox txtNotes;
        private Label lblDeservedID;
        private Label label13;
    }
}