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
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddComptoire = new Button();
            btnEditProduct = new Button();
            btnDeleteProduct = new Button();
            btnAddCategory = new Button();
            btnAddStore = new Button();
            btnExportProduct = new Button();
            ContainerPanel = new Panel();
            tabControl = new TabControl();
            OperationsflowLayoutPanel.SuspendLayout();
            ContainerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddComptoire);
            OperationsflowLayoutPanel.Controls.Add(btnEditProduct);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteProduct);
            OperationsflowLayoutPanel.Controls.Add(btnAddCategory);
            OperationsflowLayoutPanel.Controls.Add(btnAddStore);
            OperationsflowLayoutPanel.Controls.Add(btnExportProduct);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1350, 62);
            OperationsflowLayoutPanel.TabIndex = 9;
            // 
            // btnAddComptoire
            // 
            btnAddComptoire.Anchor = AnchorStyles.None;
            btnAddComptoire.Image = (Image)resources.GetObject("btnAddComptoire.Image");
            btnAddComptoire.ImageAlign = ContentAlignment.TopCenter;
            btnAddComptoire.Location = new Point(1090, 3);
            btnAddComptoire.Margin = new Padding(160, 3, 3, 3);
            btnAddComptoire.Name = "btnAddComptoire";
            btnAddComptoire.Size = new Size(100, 52);
            btnAddComptoire.TabIndex = 3;
            btnAddComptoire.Text = "اضافة";
            btnAddComptoire.TextAlign = ContentAlignment.BottomCenter;
            btnAddComptoire.UseVisualStyleBackColor = true;
            btnAddComptoire.Click += btnAddComptoire_Click;
            // 
            // btnEditProduct
            // 
            btnEditProduct.Anchor = AnchorStyles.None;
            btnEditProduct.Image = (Image)resources.GetObject("btnEditProduct.Image");
            btnEditProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditProduct.Location = new Point(927, 3);
            btnEditProduct.Margin = new Padding(60, 3, 3, 3);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(100, 52);
            btnEditProduct.TabIndex = 4;
            btnEditProduct.Text = "   تعديل";
            btnEditProduct.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Anchor = AnchorStyles.None;
            btnDeleteProduct.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteProduct.Image = (Image)resources.GetObject("btnDeleteProduct.Image");
            btnDeleteProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteProduct.Location = new Point(764, 3);
            btnDeleteProduct.Margin = new Padding(60, 3, 3, 3);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(100, 52);
            btnDeleteProduct.TabIndex = 5;
            btnDeleteProduct.Text = "   حذف";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Anchor = AnchorStyles.None;
            btnAddCategory.Image = (Image)resources.GetObject("btnAddCategory.Image");
            btnAddCategory.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddCategory.Location = new Point(580, 3);
            btnAddCategory.Margin = new Padding(60, 3, 3, 3);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(121, 52);
            btnAddCategory.TabIndex = 8;
            btnAddCategory.Text = "      اضافة صنف";
            btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // btnAddStore
            // 
            btnAddStore.Anchor = AnchorStyles.None;
            btnAddStore.BackColor = Color.White;
            btnAddStore.Image = (Image)resources.GetObject("btnAddStore.Image");
            btnAddStore.ImageAlign = ContentAlignment.TopCenter;
            btnAddStore.Location = new Point(398, 3);
            btnAddStore.Margin = new Padding(60, 3, 3, 3);
            btnAddStore.Name = "btnAddStore";
            btnAddStore.Size = new Size(119, 52);
            btnAddStore.TabIndex = 9;
            btnAddStore.Text = "الطابعة مشتعلة";
            btnAddStore.TextAlign = ContentAlignment.BottomCenter;
            btnAddStore.UseVisualStyleBackColor = false;
            // 
            // btnExportProduct
            // 
            btnExportProduct.Anchor = AnchorStyles.None;
            btnExportProduct.Image = (Image)resources.GetObject("btnExportProduct.Image");
            btnExportProduct.ImageAlign = ContentAlignment.TopCenter;
            btnExportProduct.Location = new Point(235, 3);
            btnExportProduct.Margin = new Padding(60, 3, 3, 3);
            btnExportProduct.Name = "btnExportProduct";
            btnExportProduct.Size = new Size(100, 52);
            btnExportProduct.TabIndex = 6;
            btnExportProduct.Text = "تنظيف الشاشة";
            btnExportProduct.TextAlign = ContentAlignment.BottomCenter;
            btnExportProduct.UseVisualStyleBackColor = true;
            // 
            // ContainerPanel
            // 
            ContainerPanel.Controls.Add(tabControl);
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.Location = new Point(0, 62);
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.Size = new Size(1350, 687);
            ContainerPanel.TabIndex = 10;
            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(1);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(25, 5);
            tabControl.RightToLeftLayout = true;
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1350, 687);
            tabControl.TabIndex = 0;
            tabControl.KeyDown += tabControl_KeyDown;
            // 
            // PosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1350, 749);
            Controls.Add(ContainerPanel);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            OperationsflowLayoutPanel.ResumeLayout(false);
            ContainerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddComptoire;
        private Button btnEditProduct;
        private Button btnDeleteProduct;
        private Button btnAddCategory;
        private Button btnAddStore;
        private Button btnExportProduct;
        private Panel ContainerPanel;
        private TabControl tabControl;
    }
}