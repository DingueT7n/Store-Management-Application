namespace Store.ApplicationUI.Gui.SalesGui.PosGui
{
    partial class PosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosForm));
            ContainerPanel = new Panel();
            tabControl = new TabControl();
            panel1 = new Panel();
            btnAddComptoire = new Button();
            btnCaisse = new Button();
            btnkeyboard = new Button();
            btnCalc = new Button();
            btnLastFactureA4 = new Button();
            btnPrintLastFacture = new Button();
            btnTurnOffPrinter = new Button();
            btnCleanComptoire = new Button();
            btnLockComptoire = new Button();
            btnDeleteComptoire = new Button();
            ContainerPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ContainerPanel
            // 
            ContainerPanel.Controls.Add(tabControl);
            ContainerPanel.Controls.Add(panel1);
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.Location = new Point(0, 0);
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.Size = new Size(1350, 749);
            ContainerPanel.TabIndex = 10;
            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 55);
            tabControl.Margin = new Padding(1);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(25, 5);
            tabControl.RightToLeftLayout = true;
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1350, 694);
            tabControl.TabIndex = 0;
            tabControl.KeyDown += tabControl_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddComptoire);
            panel1.Controls.Add(btnCaisse);
            panel1.Controls.Add(btnkeyboard);
            panel1.Controls.Add(btnCalc);
            panel1.Controls.Add(btnLastFactureA4);
            panel1.Controls.Add(btnPrintLastFacture);
            panel1.Controls.Add(btnTurnOffPrinter);
            panel1.Controls.Add(btnCleanComptoire);
            panel1.Controls.Add(btnLockComptoire);
            panel1.Controls.Add(btnDeleteComptoire);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 55);
            panel1.TabIndex = 15;
            // 
            // btnAddComptoire
            // 
            btnAddComptoire.Anchor = AnchorStyles.Right;
            btnAddComptoire.Image = (Image)resources.GetObject("btnAddComptoire.Image");
            btnAddComptoire.ImageAlign = ContentAlignment.TopCenter;
            btnAddComptoire.Location = new Point(1208, 1);
            btnAddComptoire.Margin = new Padding(5);
            btnAddComptoire.Name = "btnAddComptoire";
            btnAddComptoire.Size = new Size(137, 52);
            btnAddComptoire.TabIndex = 3;
            btnAddComptoire.Text = "اضافة سلة(Crtl+N)";
            btnAddComptoire.TextAlign = ContentAlignment.BottomCenter;
            btnAddComptoire.UseVisualStyleBackColor = true;
            btnAddComptoire.Click += btnAddComptoire_Click_1;
            // 
            // btnCaisse
            // 
            btnCaisse.Anchor = AnchorStyles.Left;
            btnCaisse.Image = (Image)resources.GetObject("btnCaisse.Image");
            btnCaisse.ImageAlign = ContentAlignment.TopCenter;
            btnCaisse.Location = new Point(8, 1);
            btnCaisse.Margin = new Padding(5);
            btnCaisse.Name = "btnCaisse";
            btnCaisse.Size = new Size(129, 52);
            btnCaisse.TabIndex = 13;
            btnCaisse.Text = "الحسبة في الصندوق";
            btnCaisse.TextAlign = ContentAlignment.BottomCenter;
            btnCaisse.UseVisualStyleBackColor = true;
            btnCaisse.Click += btnCaisse_Click;
            // 
            // btnkeyboard
            // 
            btnkeyboard.Anchor = AnchorStyles.Left;
            btnkeyboard.Image = (Image)resources.GetObject("btnkeyboard.Image");
            btnkeyboard.ImageAlign = ContentAlignment.TopCenter;
            btnkeyboard.Location = new Point(139, 1);
            btnkeyboard.Margin = new Padding(5);
            btnkeyboard.Name = "btnkeyboard";
            btnkeyboard.Size = new Size(129, 52);
            btnkeyboard.TabIndex = 12;
            btnkeyboard.Text = "اظهار لوحة المفاتيح";
            btnkeyboard.TextAlign = ContentAlignment.BottomCenter;
            btnkeyboard.UseVisualStyleBackColor = true;
            btnkeyboard.Click += btnkeyboard_Click;
            // 
            // btnCalc
            // 
            btnCalc.Anchor = AnchorStyles.Left;
            btnCalc.Image = (Image)resources.GetObject("btnCalc.Image");
            btnCalc.ImageAlign = ContentAlignment.TopCenter;
            btnCalc.Location = new Point(272, 1);
            btnCalc.Margin = new Padding(5);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(109, 52);
            btnCalc.TabIndex = 11;
            btnCalc.Text = "اظهار الة حاسبة";
            btnCalc.TextAlign = ContentAlignment.BottomCenter;
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // btnLastFactureA4
            // 
            btnLastFactureA4.Anchor = AnchorStyles.None;
            btnLastFactureA4.Image = (Image)resources.GetObject("btnLastFactureA4.Image");
            btnLastFactureA4.ImageAlign = ContentAlignment.TopCenter;
            btnLastFactureA4.Location = new Point(397, 1);
            btnLastFactureA4.Margin = new Padding(5);
            btnLastFactureA4.Name = "btnLastFactureA4";
            btnLastFactureA4.Size = new Size(146, 52);
            btnLastFactureA4.TabIndex = 10;
            btnLastFactureA4.Text = "طباعة اخر فاتورة (A4)";
            btnLastFactureA4.TextAlign = ContentAlignment.BottomCenter;
            btnLastFactureA4.UseVisualStyleBackColor = true;
            btnLastFactureA4.Click += btnLastFactureA4_Click_1;
            // 
            // btnPrintLastFacture
            // 
            btnPrintLastFacture.Anchor = AnchorStyles.None;
            btnPrintLastFacture.Image = (Image)resources.GetObject("btnPrintLastFacture.Image");
            btnPrintLastFacture.ImageAlign = ContentAlignment.TopCenter;
            btnPrintLastFacture.Location = new Point(548, 1);
            btnPrintLastFacture.Margin = new Padding(5);
            btnPrintLastFacture.Name = "btnPrintLastFacture";
            btnPrintLastFacture.Size = new Size(176, 52);
            btnPrintLastFacture.TabIndex = 6;
            btnPrintLastFacture.Text = "طباعة اخر فاتورة (8cm)(F3)";
            btnPrintLastFacture.TextAlign = ContentAlignment.BottomCenter;
            btnPrintLastFacture.UseVisualStyleBackColor = true;
            btnPrintLastFacture.Click += btnPrintLastFacture_Click_1;
            // 
            // btnTurnOffPrinter
            // 
            btnTurnOffPrinter.Anchor = AnchorStyles.None;
            btnTurnOffPrinter.BackColor = Color.White;
            btnTurnOffPrinter.Image = (Image)resources.GetObject("btnTurnOffPrinter.Image");
            btnTurnOffPrinter.ImageAlign = ContentAlignment.TopCenter;
            btnTurnOffPrinter.Location = new Point(731, 1);
            btnTurnOffPrinter.Margin = new Padding(5);
            btnTurnOffPrinter.Name = "btnTurnOffPrinter";
            btnTurnOffPrinter.Size = new Size(100, 52);
            btnTurnOffPrinter.TabIndex = 9;
            btnTurnOffPrinter.Text = "اطفاء الطابعة";
            btnTurnOffPrinter.TextAlign = ContentAlignment.BottomCenter;
            btnTurnOffPrinter.UseVisualStyleBackColor = false;
            btnTurnOffPrinter.Click += btnTurnOffPrinter_Click_1;
            // 
            // btnCleanComptoire
            // 
            btnCleanComptoire.Anchor = AnchorStyles.Right;
            btnCleanComptoire.Image = (Image)resources.GetObject("btnCleanComptoire.Image");
            btnCleanComptoire.ImageAlign = ContentAlignment.TopCenter;
            btnCleanComptoire.Location = new Point(835, 1);
            btnCleanComptoire.Margin = new Padding(5);
            btnCleanComptoire.Name = "btnCleanComptoire";
            btnCleanComptoire.Size = new Size(144, 52);
            btnCleanComptoire.TabIndex = 8;
            btnCleanComptoire.Text = "تنظيف السلة(Crtl+D)";
            btnCleanComptoire.TextAlign = ContentAlignment.BottomCenter;
            btnCleanComptoire.UseVisualStyleBackColor = true;
            btnCleanComptoire.Click += btnCleanComptoire_Click;
            // 
            // btnLockComptoire
            // 
            btnLockComptoire.Anchor = AnchorStyles.Right;
            btnLockComptoire.Image = (Image)resources.GetObject("btnLockComptoire.Image");
            btnLockComptoire.ImageAlign = ContentAlignment.TopCenter;
            btnLockComptoire.Location = new Point(978, 1);
            btnLockComptoire.Margin = new Padding(5);
            btnLockComptoire.Name = "btnLockComptoire";
            btnLockComptoire.Size = new Size(114, 52);
            btnLockComptoire.TabIndex = 4;
            btnLockComptoire.Text = "قفل الشاشة (F1)";
            btnLockComptoire.TextAlign = ContentAlignment.BottomCenter;
            btnLockComptoire.UseVisualStyleBackColor = true;
            btnLockComptoire.Click += btnLockComptoire_Click;
            // 
            // btnDeleteComptoire
            // 
            btnDeleteComptoire.Anchor = AnchorStyles.Right;
            btnDeleteComptoire.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteComptoire.Image = (Image)resources.GetObject("btnDeleteComptoire.Image");
            btnDeleteComptoire.ImageAlign = ContentAlignment.TopCenter;
            btnDeleteComptoire.Location = new Point(1095, 0);
            btnDeleteComptoire.Margin = new Padding(5);
            btnDeleteComptoire.Name = "btnDeleteComptoire";
            btnDeleteComptoire.Size = new Size(112, 52);
            btnDeleteComptoire.TabIndex = 5;
            btnDeleteComptoire.Text = "حذف السلة (F6)";
            btnDeleteComptoire.TextAlign = ContentAlignment.BottomCenter;
            btnDeleteComptoire.UseVisualStyleBackColor = true;
            btnDeleteComptoire.Click += btnDeleteComptoire_Click;
            // 
            // PosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1350, 749);
            Controls.Add(ContainerPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MinimizeBox = false;
            MinimumSize = new Size(1364, 718);
            Name = "PosForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += PosForm_Load;
            KeyDown += PosForm_KeyDown;
            ContainerPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel ContainerPanel;
        private TabControl tabControl;
        private Panel panel1;
        private Button btnAddComptoire;
        private Button btnCaisse;
        private Button btnkeyboard;
        private Button btnCalc;
        private Button btnLastFactureA4;
        private Button btnPrintLastFacture;
        private Button btnTurnOffPrinter;
        private Button btnCleanComptoire;
        private Button btnLockComptoire;
        private Button btnDeleteComptoire;
    }
}