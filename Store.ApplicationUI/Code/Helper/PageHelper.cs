using Store.ApplicationUI.Gui.CaisseAndBankGui;

namespace Store.ApplicationUI.Code.Helper
{
    internal class PageHelper
    {
        private readonly MainForm _main;

        public PageHelper(MainForm main)
        {
            _main = main;
        }

        //SetNewPage
        public void SetNewPage(UserControl pageUserControl)
        {
            ToasterHelper.PlayNotificationSound();
            //get the Current Page
            var oldPage = _main.ContainerPanel.Controls.OfType<UserControl>().FirstOrDefault();

            // Remove the old page

            if (oldPage != null && oldPage != pageUserControl)
            {
                _main.ContainerPanel.Controls.Remove(oldPage);
            }

            //Add New Page 
            if (pageUserControl != oldPage)

            {
                pageUserControl.Dock = DockStyle.Fill;
                _main.ContainerPanel.Controls.Add(pageUserControl);
            }
            if (_main.isPanelOpen())
                _main.CloseSubPanels();

        }
        public bool GetTheCurrentPage(UserControl pageUserControl)
        {
            //get the Current Page
            var oldPage = _main.ContainerPanel.Controls.OfType<UserControl>().FirstOrDefault();

            // Remove the old page

            if (oldPage != null && oldPage == pageUserControl)
            {
                return true;
            }

            return false;

        }
        public static void SetOperation(UserControl pageUserControl, CaisseDetailsForm detailsForm)
        {
            ToasterHelper.PlayNotificationSound();
            var oldPage = detailsForm.panelUserControls.Controls.OfType<UserControl>().FirstOrDefault();

            // Remove and dispose of the old page
            if (oldPage != null && oldPage != pageUserControl)
            {
                detailsForm.panelUserControls.Controls.Remove(oldPage);

                if (oldPage is IDisposable disposableOldPage)
                {
                    disposableOldPage.Dispose();
                }
            }

            // Add the new page
            if (pageUserControl != oldPage)
            {
                pageUserControl.Dock = DockStyle.Fill;
                detailsForm.panelUserControls.Controls.Add(pageUserControl);
                detailsForm.Size = detailsForm.MaximumSize;
            }

        }
        public UserControl? CurrentUserControl(UserControl pageUserControl)
        {
            return _main.ContainerPanel.Controls.OfType<UserControl>().FirstOrDefault();
        }

    }
}
