namespace Store.ApplicationUI.Code.Helper
{
    public static class dgvHelper
    {
        public static bool IsEmpty(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0) return false;
            return true;


        }

    }
}
