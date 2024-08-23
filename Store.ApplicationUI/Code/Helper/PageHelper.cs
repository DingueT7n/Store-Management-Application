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

        }

    }
}
