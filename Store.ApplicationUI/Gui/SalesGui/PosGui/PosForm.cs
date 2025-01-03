using System.Diagnostics;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.PaymentGui;

namespace Store.ApplicationUI.Gui.SalesGui.PosGui
{
    public partial class PosForm : Form
    {
        private bool dragging = false;
        private int draggedTabIndex;
        private static PosForm posForm;
        public PosForm()
        {
            InitializeComponent();
            InitializeTabs();
            posForm = this;



        }

        private void InitializeTabs()
        {
            // Add initial tab for client 1
            AddNewClientTab();

        }
        //private void SetColumns()
        //{

        //    DgvِProducts.Columns[0].HeaderCell.Value = "معرف المنتوج";
        //    DgvِProducts.Columns[1].HeaderCell.Value = "باركود";
        //    DgvِProducts.Columns[2].HeaderCell.Value = "اسم المنتج";
        //    DgvِProducts.Columns[3].HeaderCell.Value = "صورة المنتج";
        //    DgvِProducts.Columns[4].HeaderCell.Value = "المنتج";

        //    DgvِProducts.Columns[5].HeaderCell.Value = "معرف السرعة";
        //    DgvِProducts.Columns[3].Visible = false;
        //    DgvِProducts.Columns[4].Visible = false;
        //    DgvِProducts.Columns[5].Visible = false;
        //    DgvِProducts.Columns[0].Visible = false;
        //}
        private int count = 1;
        private async void AddNewClientTab()
        {
            //if (tabControl.TabCount < 1)
            //{

            //    DgvِProducts.DataSource = MainForm.Context.ProductQuickAccess.ToList();

            //    lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِProducts);
            //    SetColumns();
            //}
            if (tabControl.TabCount < 3)
            {
                var clientPage = new PosUserControl(this);

                var newTab = new TabPage
                {
                    Text = $"العميل رقم : {count++}",
                    ForeColor = Color.Black,
                    BackColor = Color.White,

                    Padding = new Padding(25, 5, 25, 5)
                };

                newTab.Controls.Add(clientPage);
                clientPage.Dock = DockStyle.Fill;
                tabControl.TabPages.Add(newTab);
            }
            else
            {
                MessageBox.Show("الحد الأقصى للنوافذ هو 3");

            }
        }

        private void RemoveClientTab(int index)
        {
            if (index >= 0 && index < tabControl.TabCount)
            {
                tabControl.TabPages.RemoveAt(index);
            }
        }

        private void btnAddComptoire_Click(object sender, EventArgs e)
        {
            InitializeTabs();
        }

        private void tabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && tabControl.SelectedTab != null && tabControl.TabCount > 1)
            {
                TabPage selectedTab = tabControl.SelectedTab;
                int index = tabControl.SelectedIndex;
                tabControl.TabPages.Remove(selectedTab);
                tabControl.SelectedIndex = index - 1;
            }
        }

        private void PosForm_KeyDown(object sender, KeyEventArgs e)
        {
            TabPage selectedTab = tabControl.SelectedTab;
            if (e.Control && e.KeyCode == Keys.E)
            {
                // Handle Ctrl + E combination


                if (selectedTab != null)
                {
                    foreach (Control control in selectedTab.Controls)
                    {
                        if (control is PosUserControl posUserControl)
                        {
                            // Perform actions with posUserControl


                            // Example: Call a method on PosUserControl
                            posUserControl.BringTofront(true);
                            break;
                        }
                    }
                }

            }

            if (selectedTab != null)
            {
                foreach (Control control in selectedTab.Controls)
                {
                    if (control is PosUserControl posUserControl)
                    {
                        // Perform actions with posUserControl


                        posUserControl.GetTheEventAndSender(sender, e);
                        break;
                    }
                }
            }
        }

        public static PosUserControl GetPosUserControl()
        {
            if (posForm == null) return null;
            TabPage selectedTab = posForm.tabControl.SelectedTab;
            if (selectedTab != null)
            {
                foreach (Control control in selectedTab.Controls)
                {
                    if (control is PosUserControl posUserControl)
                    {
                        // Perform actions with posUserControl
                        return posUserControl;
                    }
                }
            }
            return null;

        }
        private void PosForm_Load(object sender, EventArgs e)
        {
            posForm = this;
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null && tabControl.TabCount > 1)
            {
                TabPage selectedTab = tabControl.SelectedTab;
                int index = tabControl.SelectedIndex;
                tabControl.TabPages.Remove(selectedTab);
                tabControl.SelectedIndex = index == 0 ? 0 : --index;
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            LockUnlockForm lockUnlockForm = new LockUnlockForm();
            lockUnlockForm.ShowDialog();


        }

        private void btnCleanCart_Click(object sender, EventArgs e)
        {
            var control = GetPosUserControl();
            if (control != null)
            {
                control.CleanForm();
            }
        }

        private void btnTurnOffPrinter_Click(object sender, EventArgs e)
        {
            if (btnTurnOffPrinter.Text == "اطفاء الطابعة")
            {
                btnTurnOffPrinter.Text = "اشعال الطابعة";
                Properties.Settings.Default.PrintSaleOnOrOff = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                btnTurnOffPrinter.Text = "اطفاء الطابعة";
                Properties.Settings.Default.PrintSaleOnOrOff = true;
                Properties.Settings.Default.Save();
            }
        }

        private void btnPrintLastFacture_Click(object sender, EventArgs e)
        {
            var control = GetPosUserControl();
            if (control != null)
            {
                control.PrintLastFacture(false);
            }
        }

        private void btnLastFactureA4_Click(object sender, EventArgs e)
        {
            var control = GetPosUserControl();
            if (control != null)
            {
                control.PrintLastFacture(true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Start the calculator process
                Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching calculator: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new process for the on-screen keyboard
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "osk.exe",
                        UseShellExecute = true,
                        Verb = "runas" // Request administrative privileges
                    }
                };

                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching keyboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                // Start the calculator process
                ToasterHelper.PlayNotificationSound();
                Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching calculator: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddComptoire_Click_1(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            InitializeTabs();
        }

        private void btnDeleteComptoire_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (tabControl.SelectedTab != null && tabControl.TabCount > 1)
            {
                TabPage selectedTab = tabControl.SelectedTab;
                int index = tabControl.SelectedIndex;
                tabControl.TabPages.Remove(selectedTab);
                tabControl.SelectedIndex = index == 0 ? 0 : --index;
            }
        }

        private void btnLockComptoire_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            LockUnlockForm lockUnlockForm = new LockUnlockForm();
            lockUnlockForm.ShowDialog();
        }

        private void btnTurnOffPrinter_Click_1(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (btnTurnOffPrinter.Text == "اطفاء الطابعة")
            {
                btnTurnOffPrinter.Text = "اشعال الطابعة";
                Properties.Settings.Default.PrintSaleOnOrOff = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                btnTurnOffPrinter.Text = "اطفاء الطابعة";
                Properties.Settings.Default.PrintSaleOnOrOff = true;
                Properties.Settings.Default.Save();
            }
        }

        private void btnCleanComptoire_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            var control = GetPosUserControl();
            if (control != null)
            {
                control.CleanForm();
            }
        }

        private void btnPrintLastFacture_Click_1(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            var control = GetPosUserControl();
            if (control != null)
            {
                control.PrintLastFacture(false);
            }
        }

        private void btnLastFactureA4_Click_1(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            var control = GetPosUserControl();
            if (control != null)
            {
                control.PrintLastFacture(true);
            }
        }

        private void btnkeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new process for the on-screen keyboard
                ToasterHelper.PlayNotificationSound();
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "osk.exe",
                        UseShellExecute = true,
                        Verb = "runas" // Request administrative privileges
                    }
                };

                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching keyboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCaisse_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

        }
    }

}
