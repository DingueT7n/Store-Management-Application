namespace Store.ApplicationUI.Code.Helper
{
    public static class dgvHelper
    {
        public static bool IsEmpty(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0) return false;
            return true;


        }
        public static void ResetForm(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                switch (ctrl)
                {
                    case TextBox tb:
                        tb.Clear();
                        break;
                    case ComboBox cb:
                        cb.SelectedIndex = -1;
                        break;
                    case CheckBox chk:
                        chk.Checked = false;
                        break;

                        // Add more control types as needed
                }

                // 🔁 Recursively call for nested controls
                if (ctrl.HasChildren)
                {
                    ResetForm(ctrl);
                }
            }
        }

    }
}
