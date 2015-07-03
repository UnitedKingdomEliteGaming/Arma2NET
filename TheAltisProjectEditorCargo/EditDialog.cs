using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAltisProjectEditorCargo
{
    public partial class EditDialog : Form
    {
        private EditDialog()
        {
            InitializeComponent();
        }

        public static string ExecuteDialog_Insert(TheAltisProjectDatabase.IDatabaseCargoGui iDatabase, string table, string cargoId, string cargoType)
        {
            return ExecuteDialog(iDatabase, table, -1, cargoId, cargoType, "", true);
        }
        public static string ExecuteDialog_Update(TheAltisProjectDatabase.IDatabaseCargoGui iDatabase, string table, Int64 id, string cargoId, string cargoType, string cargoData)
        {
            return ExecuteDialog(iDatabase, table, id, cargoId, cargoType, cargoData, false);
        }
        private static string ExecuteDialog(TheAltisProjectDatabase.IDatabaseCargoGui iDatabase, string table, Int64 id, string cargoId, string cargoType, string cargoData, bool insert)
        {
            using (EditDialog dlg = new EditDialog())
            {
                dlg.txtCargoId.Text = cargoId;
                dlg.cmbCargoType.Text = cargoType;
                dlg.txtCargoData.Text = cargoData;

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    if (insert)
                        iDatabase.Insert(table, dlg.txtCargoId.Text, dlg.cmbCargoType.Text, dlg.txtCargoData.Text);
                    else
                        iDatabase.Update(table, id, dlg.txtCargoId.Text, dlg.cmbCargoType.Text, dlg.txtCargoData.Text);

                    return dlg.txtCargoId.Text;
                }

                return "";
            }
        }
    }
}
