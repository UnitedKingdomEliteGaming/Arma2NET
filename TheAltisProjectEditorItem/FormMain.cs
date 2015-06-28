using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAltisProjectEditorItem
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            MsSql.Init();
            RefreshComboboxTable();
        }

        private string SelectedTable
        {
            get
            {
                return cmbTable.SelectedItem as string;
            }
        }
        private MsSql.SqlItem SelectedItem
        {
            get
            {
                if (lvwItems.SelectedItems.Count == 1)
                    return lvwItems.SelectedItems[0].Tag as MsSql.SqlItem;
                else
                    return null;
            }
        }
        private void RefreshComboboxTable()
        {
            cmbTable.SelectedIndex = -1;
            cmbTable.Text = "";
            cmbTable.Items.Clear();
            tbtnDropTable.Enabled = false;
            string[] tables = MsSql.GetTables();
            foreach (string table in tables)
            {
                cmbTable.Items.Add(table);
            }

            cmbTable.SelectedIndex = cmbTable.Items.Count - 1;
        }
        private void RefreshListviewItems()
        {
            lvwItems.Items.Clear();

            tbtnAddItem.Enabled = !string.IsNullOrWhiteSpace(SelectedTable);
            MsSql.SqlItem[] sqlItems = MsSql.GetItems(SelectedTable);
            if (sqlItems != null)
            {
                foreach (MsSql.SqlItem sqlItem in sqlItems)
                    lvwItems.Items.Add(new ListViewItem(new string[] { sqlItem.ItemId, sqlItem.ItemData })).Tag = sqlItem;
            }
        }

        private string[] ExplodeSqfArray(string sqfArray)
        {
            List<string> result = new List<string>(8);
            try
            {
                if (!sqfArray.StartsWith("["))
                    throw new ApplicationException();
                int level = 0;
                int pos = 1;
                int start = 1;
                while (pos < sqfArray.Length)
                {
                    if (sqfArray[pos] == '[')
                        level++;
                    else if (sqfArray[pos] == ']')
                        level--;

                    if (level == 0)
                    {
                        if (sqfArray[pos] == ',')
                        {
                            result.Add(sqfArray.Substring(start, (pos - start)));
                            start = pos + 1;
                        }
                    }

                    pos++;
                }
                if (!sqfArray.EndsWith("]"))
                    throw new ApplicationException();

                result.Add(sqfArray.Substring(start, (pos - start) - 1));
            }
            catch (ApplicationException)
            {
                result.Clear();
                result.Add(sqfArray);
            }

            return result.ToArray();
        }
        private string ImplodeSqfArray(string[] texts)
        {
            string result = "[";

            foreach (string text in texts)
                result += text + ",";

            if (texts.Length > 0)
                result = result.Remove(result.Length - 1, 1);

            result += "]";
            return result;
        }

        private void tbtnDropTable_Click(object sender, EventArgs e)
        {
            string table = cmbTable.Text;
            if (MessageBox.Show("Wollen Sie wirklich die TABELLE '" + table + "' unwiederruflich löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                MsSql.DropTable(table);
                RefreshComboboxTable();
            }
        }
        private void tbtnRefreshTable_Click(object sender, EventArgs e)
        {
            RefreshComboboxTable();
        }
        private void tbtnDeleteItem_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(SelectedTable)) && (SelectedItem != null))
            {
                if (MessageBox.Show("Wollen Sie wirklich den Eintrag '" + SelectedItem.ItemId + "' unwiederruflich löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSql.Delete(SelectedTable, SelectedItem.Id);
                    RefreshListviewItems();
                    tbtnDeleteItem.Enabled = false;
                }
            }
        }
        private void tbtnAddItem_Click(object sender, EventArgs e)
        {
            if (EditDialog.ExecuteDialog_Insert(SelectedTable) != "")
            {
                RefreshListviewItems();
                lvwItems.SelectedIndices.Add(0);
            }
        }
        private void tbtnEditItem_Click(object sender, EventArgs e)
        {
            MsSql.SqlItem sqlItem = SelectedItem;
            if (sqlItem != null)
            {
                if (EditDialog.ExecuteDialog_Update(SelectedTable, sqlItem.Id, sqlItem.ItemId, sqlItem.ItemData) != "")
                {
                    int index = lvwItems.SelectedIndices[0];
                    RefreshListviewItems();
                    lvwItems.SelectedIndices.Add(index);
                }
            }
        }
        private void tbtnRefreshItems_Click(object sender, EventArgs e)
        {
            RefreshListviewItems();
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbtnDropTable.Enabled = cmbTable.SelectedIndex != -1;

            RefreshListviewItems();
        }
        private void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbtnDeleteItem.Enabled = lvwItems.SelectedItems.Count > 0;
            tbtnEditItem.Enabled = lvwItems.SelectedItems.Count > 0;
        }
        private void lvwItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbtnEditItem.PerformClick();
        }
    }
}