using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.SalesGui.PosGui
{
    public partial class PosForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;

        private int count = 1;

        public PosForm(MainForm main, ApplicationDbContext context, ControlManager controlManager)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            _controlManager = controlManager;


            InitializeTabs();
            btnTurnOffPrinter.Text = Properties.Settings.Default.PrintSaleOnOrOff
                ? "اطفاء الطابعة"
                : "اشعال الطابعة";
        }

        private void InitializeTabs()
        {
            // Add initial tab for client 1
            AddNewClientTab();

        }
        private void AddNewClientTab()
        {
            if (tabControl.TabCount < 5)
            {
                var clientPage = _controlManager.Create<PosUserControl>();

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
                MessageBox.Show("الحد الأقصى للنوافذ هو 5");
            }
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

                if (selectedTab != null)
                {
                    foreach (Control control in selectedTab.Controls)
                    {
                        if (control is PosUserControl posUserControl)
                        {
                            posUserControl.BringTofront(true);
                            break;
                        }
                    }
                }

            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                AddNewClientTab();
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                btnCleanComptoire_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnDeleteComptoire_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F1)
            {
                btnEditProduct_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnPrintLastFacture_Click_1(sender, e);
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

        public PosUserControl GetPosUserControl()
        {

            TabPage selectedTab = this.tabControl.SelectedTab;
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


        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Code.Helper.ToasterHelper.PlayNotificationSound();
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
            Code.Helper.ToasterHelper.PlayNotificationSound();
            LockUnlockForm lockUnlockForm = _controlManager.GetF<LockUnlockForm>();
            lockUnlockForm.ShowDialog();


        }

        private void btnCleanCart_Click(object sender, EventArgs e)
        {
            Code.Helper.ToasterHelper.PlayNotificationSound();
            var control = GetPosUserControl();
            if (control != null)
            {
                control.CleanForm();
            }
        }

        private void btnTurnOffPrinter_Click(object sender, EventArgs e)
        {
            Code.Helper.ToasterHelper.PlayNotificationSound();
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
        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                // Start the calculator process
                Code.Helper.ToasterHelper.PlayNotificationSound();
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
            LockUnlockForm lockUnlockForm = _controlManager.GetF<LockUnlockForm>();
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
                ToasterHelper.PlayNotificationSound();
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "osk.exe",
                        UseShellExecute = true,
                        Verb = "runas"
                    }
                };

                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching keyboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCaisse_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            var caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
            if (caisse != null)
            {
                if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Open)
                {
                    OpenOrCloseCaisseForm form = _controlManager.CreateF<OpenOrCloseCaisseForm>();


                    //Form.btnClose.Visible = true;
                    //Form.btnOpen.Visible = false;

                    form.SetPose(true);
                    form.SetMain(false);
                    if (!form.Visible)
                    {
                        form.ShowDialog();
                    }
                    else
                    {
                        form.Show(); // optional: bring it to front if already shown
                    }


                }
            }


        }
    }

}
