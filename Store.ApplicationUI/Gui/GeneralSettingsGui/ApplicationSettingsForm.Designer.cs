namespace Store.ApplicationUI.Gui.GeneralSettingsGui
{
    partial class ApplicationSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationSettingsForm));
            tabControl = new TabControl();
            tabPagePrintersSettings = new TabPage();
            button1 = new Button();
            cmbBarcode = new ComboBox();
            label3 = new Label();
            cmbA4 = new ComboBox();
            cmb8cm = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            tabPageFacturesSettings = new TabPage();
            txtNIS = new TextBox();
            label19 = new Label();
            txtIdFiscale = new TextBox();
            label18 = new Label();
            txtAI = new TextBox();
            label17 = new Label();
            txtRC = new TextBox();
            label16 = new Label();
            txtFax = new TextBox();
            label15 = new Label();
            txtStoreName = new TextBox();
            label14 = new Label();
            btnDeletePicture = new Button();
            btnChoosePicture = new Button();
            pbLogo = new PictureBox();
            button2 = new Button();
            txtAddress = new TextBox();
            txtPhoneNumber = new TextBox();
            txtSentenceUnderFacture = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            cblogoStore = new CheckBox();
            tabPageGeneralsettings = new TabPage();
            groupBox1 = new GroupBox();
            cbDirectLogin = new CheckBox();
            cbStockNegative = new CheckBox();
            button3 = new Button();
            cbSalePrinterState = new CheckBox();
            cbBuyPrinterState = new CheckBox();
            txtBuyCopy = new TextBox();
            label12 = new Label();
            txtSaleCopy = new TextBox();
            label13 = new Label();
            txtDataInDgv = new TextBox();
            label11 = new Label();
            txtDaysDelaysDebt = new TextBox();
            label10 = new Label();
            gbFastSales = new GroupBox();
            groupBox4 = new GroupBox();
            cbEditWholeSaleprice = new CheckBox();
            cbEditSalePrice = new CheckBox();
            cbEditBuyPrice = new CheckBox();
            groupBox3 = new GroupBox();
            rbBuyA4 = new RadioButton();
            rbBuy8cm = new RadioButton();
            groupBox2 = new GroupBox();
            rbSaleA4 = new RadioButton();
            rbSale8cm = new RadioButton();
            cmbFastCaisse = new ComboBox();
            cmbFastStores = new ComboBox();
            label6 = new Label();
            label9 = new Label();
            label8 = new Label();
            cmbCustomers = new ComboBox();
            tabControl.SuspendLayout();
            tabPagePrintersSettings.SuspendLayout();
            tabPageFacturesSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            tabPageGeneralsettings.SuspendLayout();
            groupBox1.SuspendLayout();
            gbFastSales.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPagePrintersSettings);
            tabControl.Controls.Add(tabPageFacturesSettings);
            tabControl.Controls.Add(tabPageGeneralsettings);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.RightToLeftLayout = true;
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(751, 511);
            tabControl.TabIndex = 0;
            // 
            // tabPagePrintersSettings
            // 
            tabPagePrintersSettings.BackColor = Color.White;
            tabPagePrintersSettings.Controls.Add(button1);
            tabPagePrintersSettings.Controls.Add(cmbBarcode);
            tabPagePrintersSettings.Controls.Add(label3);
            tabPagePrintersSettings.Controls.Add(cmbA4);
            tabPagePrintersSettings.Controls.Add(cmb8cm);
            tabPagePrintersSettings.Controls.Add(label2);
            tabPagePrintersSettings.Controls.Add(label1);
            tabPagePrintersSettings.Location = new Point(4, 28);
            tabPagePrintersSettings.Name = "tabPagePrintersSettings";
            tabPagePrintersSettings.Padding = new Padding(3);
            tabPagePrintersSettings.Size = new Size(743, 479);
            tabPagePrintersSettings.TabIndex = 0;
            tabPagePrintersSettings.Text = "اعدادات الطابعات";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(221, 281);
            button1.Name = "button1";
            button1.Size = new Size(273, 45);
            button1.TabIndex = 20;
            button1.Text = "حفظ بيانات البرنامج";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cmbBarcode
            // 
            cmbBarcode.FormattingEnabled = true;
            cmbBarcode.Location = new Point(366, 182);
            cmbBarcode.Name = "cmbBarcode";
            cmbBarcode.Size = new Size(249, 27);
            cmbBarcode.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(646, 182);
            label3.Name = "label3";
            label3.Size = new Size(89, 19);
            label3.TabIndex = 4;
            label3.Text = "طابعة الباركود:";
            // 
            // cmbA4
            // 
            cmbA4.FormattingEnabled = true;
            cmbA4.Location = new Point(366, 113);
            cmbA4.Name = "cmbA4";
            cmbA4.Size = new Size(249, 27);
            cmbA4.TabIndex = 3;
            // 
            // cmb8cm
            // 
            cmb8cm.FormattingEnabled = true;
            cmb8cm.Location = new Point(366, 46);
            cmb8cm.Name = "cmb8cm";
            cmb8cm.Size = new Size(249, 27);
            cmb8cm.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(665, 121);
            label2.Name = "label2";
            label2.Size = new Size(70, 19);
            label2.TabIndex = 1;
            label2.Text = "طابعة A4 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(634, 46);
            label1.Name = "label1";
            label1.Size = new Size(102, 19);
            label1.TabIndex = 0;
            label1.Text = "طابعة 8 سنتيمتر:";
            // 
            // tabPageFacturesSettings
            // 
            tabPageFacturesSettings.BackColor = Color.White;
            tabPageFacturesSettings.Controls.Add(txtNIS);
            tabPageFacturesSettings.Controls.Add(label19);
            tabPageFacturesSettings.Controls.Add(txtIdFiscale);
            tabPageFacturesSettings.Controls.Add(label18);
            tabPageFacturesSettings.Controls.Add(txtAI);
            tabPageFacturesSettings.Controls.Add(label17);
            tabPageFacturesSettings.Controls.Add(txtRC);
            tabPageFacturesSettings.Controls.Add(label16);
            tabPageFacturesSettings.Controls.Add(txtFax);
            tabPageFacturesSettings.Controls.Add(label15);
            tabPageFacturesSettings.Controls.Add(txtStoreName);
            tabPageFacturesSettings.Controls.Add(label14);
            tabPageFacturesSettings.Controls.Add(btnDeletePicture);
            tabPageFacturesSettings.Controls.Add(btnChoosePicture);
            tabPageFacturesSettings.Controls.Add(pbLogo);
            tabPageFacturesSettings.Controls.Add(button2);
            tabPageFacturesSettings.Controls.Add(txtAddress);
            tabPageFacturesSettings.Controls.Add(txtPhoneNumber);
            tabPageFacturesSettings.Controls.Add(txtSentenceUnderFacture);
            tabPageFacturesSettings.Controls.Add(label7);
            tabPageFacturesSettings.Controls.Add(label5);
            tabPageFacturesSettings.Controls.Add(label4);
            tabPageFacturesSettings.Controls.Add(cblogoStore);
            tabPageFacturesSettings.Location = new Point(4, 28);
            tabPageFacturesSettings.Name = "tabPageFacturesSettings";
            tabPageFacturesSettings.Padding = new Padding(3);
            tabPageFacturesSettings.Size = new Size(743, 479);
            tabPageFacturesSettings.TabIndex = 1;
            tabPageFacturesSettings.Text = "اعدادات الفاتورة";
            // 
            // txtNIS
            // 
            txtNIS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNIS.Location = new Point(9, 253);
            txtNIS.Name = "txtNIS";
            txtNIS.PlaceholderText = "ادخل NIS";
            txtNIS.Size = new Size(232, 27);
            txtNIS.TabIndex = 36;
            txtNIS.TextAlign = HorizontalAlignment.Center;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(246, 256);
            label19.Name = "label19";
            label19.Size = new Size(165, 19);
            label19.TabIndex = 35;
            label19.Text = "رقم التعريف الإحصائي (NIS):";
            // 
            // txtIdFiscale
            // 
            txtIdFiscale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtIdFiscale.Location = new Point(9, 205);
            txtIdFiscale.Name = "txtIdFiscale";
            txtIdFiscale.PlaceholderText = "ادخل معرف الضريبة (NIF)";
            txtIdFiscale.Size = new Size(232, 27);
            txtIdFiscale.TabIndex = 34;
            txtIdFiscale.TextAlign = HorizontalAlignment.Center;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(246, 208);
            label18.Name = "label18";
            label18.Size = new Size(165, 19);
            label18.TabIndex = 33;
            label18.Text = "معرف الضريبة (ID Fiscale):";
            // 
            // txtAI
            // 
            txtAI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAI.Location = new Point(9, 160);
            txtAI.Name = "txtAI";
            txtAI.PlaceholderText = "ادخل مقالة التسجيل";
            txtAI.Size = new Size(232, 27);
            txtAI.TabIndex = 32;
            txtAI.TextAlign = HorizontalAlignment.Center;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(246, 163);
            label17.Name = "label17";
            label17.Size = new Size(118, 19);
            label17.TabIndex = 31;
            label17.Text = "مقالة التسجيل (AI):";
            // 
            // txtRC
            // 
            txtRC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRC.Location = new Point(9, 113);
            txtRC.Name = "txtRC";
            txtRC.PlaceholderText = "ادخل السجل التجاري";
            txtRC.Size = new Size(232, 27);
            txtRC.TabIndex = 30;
            txtRC.TextAlign = HorizontalAlignment.Center;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(246, 116);
            label16.Name = "label16";
            label16.Size = new Size(112, 19);
            label16.TabIndex = 29;
            label16.Text = "سجل تجاري (RC):";
            // 
            // txtFax
            // 
            txtFax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFax.Location = new Point(415, 305);
            txtFax.Name = "txtFax";
            txtFax.PlaceholderText = "ادخل رقم الفاكس";
            txtFax.Size = new Size(232, 27);
            txtFax.TabIndex = 28;
            txtFax.TextAlign = HorizontalAlignment.Center;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(664, 308);
            label15.Name = "label15";
            label15.Size = new Size(74, 19);
            label15.TabIndex = 27;
            label15.Text = "رقم الفاكس:";
            // 
            // txtStoreName
            // 
            txtStoreName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtStoreName.Location = new Point(415, 215);
            txtStoreName.Name = "txtStoreName";
            txtStoreName.PlaceholderText = "ادخل اسم المحل";
            txtStoreName.Size = new Size(232, 27);
            txtStoreName.TabIndex = 26;
            txtStoreName.TextAlign = HorizontalAlignment.Center;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(664, 218);
            label14.Name = "label14";
            label14.Size = new Size(71, 19);
            label14.TabIndex = 25;
            label14.Text = "اسم المحل:";
            // 
            // btnDeletePicture
            // 
            btnDeletePicture.Anchor = AnchorStyles.None;
            btnDeletePicture.Enabled = false;
            btnDeletePicture.Image = (Image)resources.GetObject("btnDeletePicture.Image");
            btnDeletePicture.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeletePicture.Location = new Point(396, 143);
            btnDeletePicture.Name = "btnDeletePicture";
            btnDeletePicture.Size = new Size(113, 34);
            btnDeletePicture.TabIndex = 24;
            btnDeletePicture.Text = "امسح الصورة";
            btnDeletePicture.TextAlign = ContentAlignment.MiddleRight;
            btnDeletePicture.UseVisualStyleBackColor = true;
            btnDeletePicture.Click += button4_Click;
            // 
            // btnChoosePicture
            // 
            btnChoosePicture.Anchor = AnchorStyles.None;
            btnChoosePicture.Enabled = false;
            btnChoosePicture.Image = (Image)resources.GetObject("btnChoosePicture.Image");
            btnChoosePicture.ImageAlign = ContentAlignment.MiddleLeft;
            btnChoosePicture.Location = new Point(529, 143);
            btnChoosePicture.Name = "btnChoosePicture";
            btnChoosePicture.Size = new Size(105, 34);
            btnChoosePicture.TabIndex = 23;
            btnChoosePicture.Text = "اختر الصورة";
            btnChoosePicture.TextAlign = ContentAlignment.MiddleRight;
            btnChoosePicture.UseVisualStyleBackColor = true;
            btnChoosePicture.Click += button3_Click;
            // 
            // pbLogo
            // 
            pbLogo.BorderStyle = BorderStyle.FixedSingle;
            pbLogo.Enabled = false;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(396, 20);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(238, 117);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 22;
            pbLogo.TabStop = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(189, 344);
            button2.Name = "button2";
            button2.Size = new Size(273, 45);
            button2.TabIndex = 21;
            button2.Text = "حفظ بيانات البرنامج";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAddress.Location = new Point(9, 65);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "ادخل عنوان المحل";
            txtAddress.Size = new Size(232, 27);
            txtAddress.TabIndex = 10;
            txtAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPhoneNumber.Location = new Point(415, 258);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "ادخل رقم الهاتف";
            txtPhoneNumber.Size = new Size(232, 27);
            txtPhoneNumber.TabIndex = 9;
            txtPhoneNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // txtSentenceUnderFacture
            // 
            txtSentenceUnderFacture.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSentenceUnderFacture.Location = new Point(9, 20);
            txtSentenceUnderFacture.Name = "txtSentenceUnderFacture";
            txtSentenceUnderFacture.PlaceholderText = "ادخل الجملة";
            txtSentenceUnderFacture.Size = new Size(232, 27);
            txtSentenceUnderFacture.TabIndex = 7;
            txtSentenceUnderFacture.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(664, 261);
            label7.Name = "label7";
            label7.Size = new Size(71, 19);
            label7.TabIndex = 6;
            label7.Text = "رقم الهاتف:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 23);
            label5.Name = "label5";
            label5.Size = new Size(125, 19);
            label5.TabIndex = 4;
            label5.Text = "الجملة اسفل الفاتورة:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(246, 68);
            label4.Name = "label4";
            label4.Size = new Size(82, 19);
            label4.TabIndex = 3;
            label4.Text = "عنوان المحل:";
            // 
            // cblogoStore
            // 
            cblogoStore.AutoSize = true;
            cblogoStore.Location = new Point(640, 27);
            cblogoStore.Name = "cblogoStore";
            cblogoStore.Size = new Size(95, 23);
            cblogoStore.TabIndex = 2;
            cblogoStore.Text = "لوغو المحل:";
            cblogoStore.UseVisualStyleBackColor = true;
            cblogoStore.CheckedChanged += cblogoStore_CheckedChanged;
            // 
            // tabPageGeneralsettings
            // 
            tabPageGeneralsettings.BackColor = Color.White;
            tabPageGeneralsettings.Controls.Add(groupBox1);
            tabPageGeneralsettings.Controls.Add(gbFastSales);
            tabPageGeneralsettings.Location = new Point(4, 28);
            tabPageGeneralsettings.Name = "tabPageGeneralsettings";
            tabPageGeneralsettings.Padding = new Padding(3);
            tabPageGeneralsettings.Size = new Size(743, 479);
            tabPageGeneralsettings.TabIndex = 2;
            tabPageGeneralsettings.Text = "اعدادات عامة";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbDirectLogin);
            groupBox1.Controls.Add(cbStockNegative);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(cbSalePrinterState);
            groupBox1.Controls.Add(cbBuyPrinterState);
            groupBox1.Controls.Add(txtBuyCopy);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtSaleCopy);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(txtDataInDgv);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtDaysDelaysDebt);
            groupBox1.Controls.Add(label10);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(412, 473);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "معلومات اختيارية";
            // 
            // cbDirectLogin
            // 
            cbDirectLogin.AutoSize = true;
            cbDirectLogin.Location = new Point(214, 349);
            cbDirectLogin.Name = "cbDirectLogin";
            cbDirectLogin.Size = new Size(192, 23);
            cbDirectLogin.TabIndex = 24;
            cbDirectLogin.Text = "الدخول المباشر بدون التسجيل";
            cbDirectLogin.UseVisualStyleBackColor = true;
            // 
            // cbStockNegative
            // 
            cbStockNegative.AutoSize = true;
            cbStockNegative.Location = new Point(228, 309);
            cbStockNegative.Name = "cbStockNegative";
            cbStockNegative.Size = new Size(178, 23);
            cbStockNegative.TabIndex = 23;
            cbStockNegative.Text = "الكمية بالسالب في المنتجات";
            cbStockNegative.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(60, 422);
            button3.Name = "button3";
            button3.Size = new Size(215, 45);
            button3.TabIndex = 22;
            button3.Text = "حفظ بيانات البرنامج";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // cbSalePrinterState
            // 
            cbSalePrinterState.AutoSize = true;
            cbSalePrinterState.Checked = true;
            cbSalePrinterState.CheckState = CheckState.Checked;
            cbSalePrinterState.Location = new Point(223, 233);
            cbSalePrinterState.Name = "cbSalePrinterState";
            cbSalePrinterState.Size = new Size(183, 23);
            cbSalePrinterState.TabIndex = 17;
            cbSalePrinterState.Text = "تفعيل طباعة فواتير المبيعات";
            cbSalePrinterState.UseVisualStyleBackColor = true;
            // 
            // cbBuyPrinterState
            // 
            cbBuyPrinterState.AutoSize = true;
            cbBuyPrinterState.Checked = true;
            cbBuyPrinterState.CheckState = CheckState.Checked;
            cbBuyPrinterState.Location = new Point(217, 273);
            cbBuyPrinterState.Name = "cbBuyPrinterState";
            cbBuyPrinterState.Size = new Size(189, 23);
            cbBuyPrinterState.TabIndex = 16;
            cbBuyPrinterState.Text = "تفعيل طباعة فواتير المشتريات";
            cbBuyPrinterState.UseVisualStyleBackColor = true;
            // 
            // txtBuyCopy
            // 
            txtBuyCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBuyCopy.Location = new Point(6, 184);
            txtBuyCopy.Name = "txtBuyCopy";
            txtBuyCopy.PlaceholderText = "نسخ المشتريات";
            txtBuyCopy.Size = new Size(189, 27);
            txtBuyCopy.TabIndex = 15;
            txtBuyCopy.TextAlign = HorizontalAlignment.Center;
            txtBuyCopy.KeyPress += txtDaysDelaysDebt_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(205, 187);
            label12.Name = "label12";
            label12.Size = new Size(201, 19);
            label12.TabIndex = 14;
            label12.Text = "عدد طباعة نسخة فواتير المشتريات:";
            // 
            // txtSaleCopy
            // 
            txtSaleCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSaleCopy.Location = new Point(6, 137);
            txtSaleCopy.Name = "txtSaleCopy";
            txtSaleCopy.PlaceholderText = "نسخ المبيعات";
            txtSaleCopy.Size = new Size(189, 27);
            txtSaleCopy.TabIndex = 13;
            txtSaleCopy.TextAlign = HorizontalAlignment.Center;
            txtSaleCopy.KeyPress += txtDaysDelaysDebt_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(211, 140);
            label13.Name = "label13";
            label13.Size = new Size(195, 19);
            label13.TabIndex = 12;
            label13.Text = "عدد طباعة نسخة فواتير المبيعات:";
            // 
            // txtDataInDgv
            // 
            txtDataInDgv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDataInDgv.Location = new Point(6, 83);
            txtDataInDgv.Name = "txtDataInDgv";
            txtDataInDgv.PlaceholderText = "ادخل رقم البيانات";
            txtDataInDgv.Size = new Size(189, 27);
            txtDataInDgv.TabIndex = 11;
            txtDataInDgv.TextAlign = HorizontalAlignment.Center;
            txtDataInDgv.KeyPress += txtDaysDelaysDebt_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(250, 86);
            label11.Name = "label11";
            label11.Size = new Size(156, 19);
            label11.TabIndex = 10;
            label11.Text = "عدد المعلومات في الجداول:";
            // 
            // txtDaysDelaysDebt
            // 
            txtDaysDelaysDebt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDaysDelaysDebt.Location = new Point(6, 36);
            txtDaysDelaysDebt.Name = "txtDaysDelaysDebt";
            txtDaysDelaysDebt.PlaceholderText = "ادخل عدد الايام للدين";
            txtDaysDelaysDebt.Size = new Size(189, 27);
            txtDaysDelaysDebt.TabIndex = 9;
            txtDaysDelaysDebt.TextAlign = HorizontalAlignment.Center;
            txtDaysDelaysDebt.KeyPress += txtDaysDelaysDebt_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(280, 39);
            label10.Name = "label10";
            label10.Size = new Size(126, 19);
            label10.TabIndex = 8;
            label10.Text = "عدد ايام تأجيل الدين:";
            // 
            // gbFastSales
            // 
            gbFastSales.Controls.Add(groupBox4);
            gbFastSales.Controls.Add(groupBox3);
            gbFastSales.Controls.Add(groupBox2);
            gbFastSales.Controls.Add(cmbFastCaisse);
            gbFastSales.Controls.Add(cmbFastStores);
            gbFastSales.Controls.Add(label6);
            gbFastSales.Controls.Add(label9);
            gbFastSales.Controls.Add(label8);
            gbFastSales.Controls.Add(cmbCustomers);
            gbFastSales.Dock = DockStyle.Right;
            gbFastSales.Location = new Point(421, 3);
            gbFastSales.Name = "gbFastSales";
            gbFastSales.Size = new Size(319, 473);
            gbFastSales.TabIndex = 9;
            gbFastSales.TabStop = false;
            gbFastSales.Text = "بيانات البيع السريع";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cbEditWholeSaleprice);
            groupBox4.Controls.Add(cbEditSalePrice);
            groupBox4.Controls.Add(cbEditBuyPrice);
            groupBox4.Location = new Point(6, 359);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(307, 108);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "اعدادات المشتريات (تعديل على المنتجات)";
            // 
            // cbEditWholeSaleprice
            // 
            cbEditWholeSaleprice.AutoSize = true;
            cbEditWholeSaleprice.Location = new Point(35, 26);
            cbEditWholeSaleprice.Name = "cbEditWholeSaleprice";
            cbEditWholeSaleprice.Size = new Size(126, 23);
            cbEditWholeSaleprice.TabIndex = 2;
            cbEditWholeSaleprice.Text = "تعديل سعر الجملة";
            cbEditWholeSaleprice.UseVisualStyleBackColor = true;
            // 
            // cbEditSalePrice
            // 
            cbEditSalePrice.AutoSize = true;
            cbEditSalePrice.Location = new Point(153, 63);
            cbEditSalePrice.Name = "cbEditSalePrice";
            cbEditSalePrice.Size = new Size(154, 23);
            cbEditSalePrice.TabIndex = 1;
            cbEditSalePrice.Text = "تعديل سعر البيع 1 و 2 ";
            cbEditSalePrice.UseVisualStyleBackColor = true;
            // 
            // cbEditBuyPrice
            // 
            cbEditBuyPrice.AutoSize = true;
            cbEditBuyPrice.Location = new Point(183, 26);
            cbEditBuyPrice.Name = "cbEditBuyPrice";
            cbEditBuyPrice.Size = new Size(122, 23);
            cbEditBuyPrice.TabIndex = 0;
            cbEditBuyPrice.Text = "تعديل سعر الشراء";
            cbEditBuyPrice.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbBuyA4);
            groupBox3.Controls.Add(rbBuy8cm);
            groupBox3.Location = new Point(6, 273);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(307, 80);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "طباعة فواتير المشتريات";
            // 
            // rbBuyA4
            // 
            rbBuyA4.AutoSize = true;
            rbBuyA4.Location = new Point(6, 35);
            rbBuyA4.Name = "rbBuyA4";
            rbBuyA4.Size = new Size(80, 23);
            rbBuyA4.TabIndex = 11;
            rbBuyA4.Text = "طابعة A4";
            rbBuyA4.UseVisualStyleBackColor = true;
            // 
            // rbBuy8cm
            // 
            rbBuy8cm.AutoSize = true;
            rbBuy8cm.Checked = true;
            rbBuy8cm.Location = new Point(155, 35);
            rbBuy8cm.Name = "rbBuy8cm";
            rbBuy8cm.Size = new Size(146, 23);
            rbBuy8cm.TabIndex = 10;
            rbBuy8cm.TabStop = true;
            rbBuy8cm.Text = "طابعة حرارية (8سنتي)";
            rbBuy8cm.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbSaleA4);
            groupBox2.Controls.Add(rbSale8cm);
            groupBox2.Location = new Point(6, 187);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(307, 80);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "طباعة فواتير المبيعات";
            // 
            // rbSaleA4
            // 
            rbSaleA4.AutoSize = true;
            rbSaleA4.Location = new Point(6, 35);
            rbSaleA4.Name = "rbSaleA4";
            rbSaleA4.Size = new Size(80, 23);
            rbSaleA4.TabIndex = 11;
            rbSaleA4.Text = "طابعة A4";
            rbSaleA4.UseVisualStyleBackColor = true;
            // 
            // rbSale8cm
            // 
            rbSale8cm.AutoSize = true;
            rbSale8cm.Checked = true;
            rbSale8cm.Location = new Point(155, 35);
            rbSale8cm.Name = "rbSale8cm";
            rbSale8cm.Size = new Size(146, 23);
            rbSale8cm.TabIndex = 10;
            rbSale8cm.TabStop = true;
            rbSale8cm.Text = "طابعة حرارية (8سنتي)";
            rbSale8cm.UseVisualStyleBackColor = true;
            // 
            // cmbFastCaisse
            // 
            cmbFastCaisse.Anchor = AnchorStyles.None;
            cmbFastCaisse.FormattingEnabled = true;
            cmbFastCaisse.Location = new Point(29, 44);
            cmbFastCaisse.Name = "cmbFastCaisse";
            cmbFastCaisse.Size = new Size(151, 27);
            cmbFastCaisse.TabIndex = 4;
            // 
            // cmbFastStores
            // 
            cmbFastStores.Anchor = AnchorStyles.None;
            cmbFastStores.FormattingEnabled = true;
            cmbFastStores.Location = new Point(29, 150);
            cmbFastStores.Name = "cmbFastStores";
            cmbFastStores.Size = new Size(151, 27);
            cmbFastStores.TabIndex = 8;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(189, 47);
            label6.Name = "label6";
            label6.Size = new Size(124, 19);
            label6.TabIndex = 3;
            label6.Text = "صندوق البيع السريع:";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Location = new Point(200, 153);
            label9.Name = "label9";
            label9.Size = new Size(113, 19);
            label9.TabIndex = 7;
            label9.Text = "مخزن البيع السريع:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new Point(184, 99);
            label8.Name = "label8";
            label8.Size = new Size(129, 19);
            label8.TabIndex = 5;
            label8.Text = "الزبون العادي (عادي):";
            // 
            // cmbCustomers
            // 
            cmbCustomers.Anchor = AnchorStyles.None;
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(29, 96);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(151, 27);
            cmbCustomers.TabIndex = 6;
            // 
            // ApplicationSettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(751, 511);
            Controls.Add(tabControl);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(767, 550);
            MinimizeBox = false;
            MinimumSize = new Size(767, 550);
            Name = "ApplicationSettingsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اعدادات البرنامج";
            tabControl.ResumeLayout(false);
            tabPagePrintersSettings.ResumeLayout(false);
            tabPagePrintersSettings.PerformLayout();
            tabPageFacturesSettings.ResumeLayout(false);
            tabPageFacturesSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            tabPageGeneralsettings.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbFastSales.ResumeLayout(false);
            gbFastSales.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPagePrintersSettings;
        private Label label1;
        private Label label2;
        private ComboBox cmbBarcode;
        private Label label3;
        private ComboBox cmbA4;
        private ComboBox cmb8cm;
        private Button button1;
        private TabPage tabPageFacturesSettings;
        private CheckBox cblogoStore;
        private Label label4;
        private Label label7;
        private Label label5;
        private TextBox txtPhoneNumber;
        private TextBox txtSentenceUnderFacture;
        private TextBox txtAddress;
        private Button button2;
        private Button btnDeletePicture;
        private Button btnChoosePicture;
        private PictureBox pbLogo;
        private TabPage tabPageGeneralsettings;
        private ComboBox cmbFastCaisse;
        private Label label6;
        private ComboBox cmbCustomers;
        private Label label8;
        private ComboBox cmbFastStores;
        private Label label9;
        private GroupBox gbFastSales;
        private GroupBox groupBox1;
        private TextBox txtDaysDelaysDebt;
        private Label label10;
        private TextBox txtDataInDgv;
        private Label label11;
        private TextBox txtBuyCopy;
        private Label label12;
        private TextBox txtSaleCopy;
        private Label label13;
        private CheckBox cbSalePrinterState;
        private CheckBox cbBuyPrinterState;
        private RadioButton rbSaleA4;
        private RadioButton rbSale8cm;
        private GroupBox groupBox3;
        private RadioButton rbBuyA4;
        private RadioButton rbBuy8cm;
        private GroupBox groupBox2;
        private Button button3;
        private TextBox txtStoreName;
        private Label label14;
        private TextBox txtFax;
        private Label label15;
        private TextBox txtAI;
        private Label label17;
        private TextBox txtRC;
        private Label label16;
        private TextBox txtIdFiscale;
        private Label label18;
        private TextBox txtNIS;
        private Label label19;
        private GroupBox groupBox4;
        private CheckBox cbEditWholeSaleprice;
        private CheckBox cbEditSalePrice;
        private CheckBox cbEditBuyPrice;
        private CheckBox cbStockNegative;
        private CheckBox cbDirectLogin;
    }
}