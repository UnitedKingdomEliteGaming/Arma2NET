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

        public static string ExecuteDialog_Insert(string table, string cargoId, string cargoType)
        {
            return ExecuteDialog(table, -1, cargoId, cargoType, "", true);
        }
        public static string ExecuteDialog_Update(string table, Int64 id, string cargoId, string cargoType, string cargoData)
        {
            return ExecuteDialog(table, id, cargoId, cargoType, cargoData, false);
        }
        private static string ExecuteDialog(string table, Int64 id, string cargoId, string cargoType, string cargoData, bool insert)
        {
            using (EditDialog dlg = new EditDialog())
            {
                dlg.txtCargoId.Text = cargoId;
                dlg.cmbCargoType.Text = cargoType;
                dlg.txtCargoData.Text = cargoData;

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    if (insert)
                        MsSql.Insert(table, dlg.txtCargoId.Text, dlg.cmbCargoType.Text, dlg.txtCargoData.Text);
                    else
                        MsSql.Update(table, dlg.txtCargoId.Text, dlg.cmbCargoType.Text, dlg.txtCargoData.Text);

                    return dlg.txtCargoId.Text;
                }

                return "";
            }
        }
    }
}
