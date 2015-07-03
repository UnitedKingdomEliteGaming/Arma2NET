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
    public partial class EditDialog : Form
    {
        private EditDialog()
        {
            InitializeComponent();
        }

        public static string ExecuteDialog_Insert(TheAltisProjectDatabase.IDatabaseItemGui iDatabase, string table)
        {
            return ExecuteDialog(iDatabase, table, -1, "eindeutige id", "data", true);
        }
        public static string ExecuteDialog_Update(TheAltisProjectDatabase.IDatabaseItemGui iDatabase, string table, Int64 id, string itemId, string itemData)
        {
            return ExecuteDialog(iDatabase, table, id, itemId, itemData, false);
        }
        private static string ExecuteDialog(TheAltisProjectDatabase.IDatabaseItemGui iDatabase, string table, Int64 id, string itemId, string itemData, bool insert)
        {
            using (EditDialog dlg = new EditDialog())
            {
                dlg.txtItemId.Text = itemId;
                dlg.txtItemData.Text = itemData;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (insert)
                        iDatabase.InsertItemId(table, dlg.txtItemId.Text, dlg.txtItemData.Text);
                    else
                        iDatabase.UpdateId(table, id, dlg.txtItemId.Text, dlg.txtItemData.Text);

                    return dlg.txtItemId.Text;
                }

                return "";
            }
        }
    }
}
