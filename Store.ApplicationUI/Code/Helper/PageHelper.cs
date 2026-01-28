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
            if (Code.Models.LocalUser.User is null)
                return;

            ToasterHelper.PlayNotificationSound();

            var existingControl = detailsForm.panelUserControls.Controls
                .OfType<UserControl>()
                .FirstOrDefault();

            // Remove and dispose the old control if different from the new one
            if (existingControl != null && existingControl != pageUserControl)
            {
                detailsForm.panelUserControls.Controls.Remove(existingControl);
            }

            // If not already added, add and dock the new control
            if (!detailsForm.panelUserControls.Controls.Contains(pageUserControl))
            {
                pageUserControl.Dock = DockStyle.Fill;
                detailsForm.panelUserControls.Controls.Add(pageUserControl);
            }

            // Resize the form to fit the new control (optional)
            detailsForm.Size = detailsForm.MaximumSize;

            // Automatically invoke LoadData method if exists
            //var loadDataMethod = pageUserControl.GetType()
            //    .GetMethod("LoadData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            //loadDataMethod?.Invoke(pageUserControl, null);
        }

        public UserControl? CurrentUserControl()
        {
            return _main.ContainerPanel.Controls.OfType<UserControl>().FirstOrDefault();
        }

    }
}
