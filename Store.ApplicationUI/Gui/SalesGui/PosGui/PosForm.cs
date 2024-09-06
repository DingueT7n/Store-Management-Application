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

        private void AddNewClientTab()
        {
            if (tabControl.TabCount < 3)
            {
                var clientPage = new PosUserControl(this);
                var count = tabControl.TabCount + 1;
                var newTab = new TabPage
                {
                    Text = $"العميل رقم : {count}",
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
                tabControl.TabPages.Remove(selectedTab);
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
            TabPage selectedTab = posForm.tabControl.TabPages[posForm.tabControl.TabIndex];
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
    }

}
