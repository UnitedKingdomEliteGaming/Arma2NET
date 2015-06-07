using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAltisProjectEditorCargo
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();

            MsSql.Init();

            cmbCargoType.SelectedIndex = 0;
            RefreshComboboxTable();
            cmbTable.SelectedIndex = cmbTable.Items.Count -1;
        }

        private string SelectedTable
        {
            get
            {
                return cmbTable.SelectedItem as string;
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
        private void RefreshListCargoId()
        {
            string[] cargoIds = MsSql.GetCargoIds(SelectedTable);
            lstCargoId.Items.Clear();
            if (cargoIds != null)
            {
                foreach (string cargoId in cargoIds)
                    lstCargoId.Items.Add(cargoId);
            }

            RefreshListCargoData();
        }
        private void RefreshListCargoData()
        {
            lstCargoData.Items.Clear();
            if ((lstCargoId.SelectedItem != null) && (cmbCargoType.Text.Length == 3))
            {
                MsSql.IdStringPair[] cargoDatas = MsSql.GetCargoData(SelectedTable, (lstCargoId.SelectedItem as string), cmbCargoType.Text);
                lstCargoData.Items.Clear();
                if (cargoDatas != null)
                {
                    foreach (MsSql.IdStringPair cargoData in cargoDatas)
                        lstCargoData.Items.Add(cargoData);
                }
                tbtnDeleteCargoDataType.Enabled = lstCargoData.Items.Count > 0;
            }
        }

        private void tbtnDropTable_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SelectedTable))
            {
                if (MessageBox.Show("Wollen Sie wirklich den Table " + SelectedTable + " löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSql.DropTable(SelectedTable);
                    RefreshComboboxTable();
                }
            }
        }
        private void tbtnRefreshTable_Click(object sender, EventArgs e)
        {
            RefreshComboboxTable();
        }

        private void tbtnDeleteCargoId_Click(object sender, EventArgs e)
        {
            if (lstCargoId.SelectedIndex != -1)
            {
                if (MessageBox.Show("Wollen Sie wirklich alle Einträge dieser Cargo Id löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSql.DeleteCargoId(SelectedTable, (lstCargoId.SelectedItem as string));
                    RefreshListCargoId();
                }
            }
        }
        private void tbtnRefreshCargoId_Click(object sender, EventArgs e)
        {
            RefreshListCargoId();
        }

        private void tbtnEditCargoData_Click(object sender, EventArgs e)
        {
            string cargoId = "";
            if (lstCargoId.SelectedItem != null)
                cargoId = (lstCargoId.SelectedItem as string);
            
            string cargoType = "";
            if (cmbCargoType.Text.Length == 3)
                cargoType = cmbCargoType.Text;

            Int64 id = -1;
            string cargoData = "";
            if (lstCargoData.SelectedItem != null)
            {
                id = (lstCargoData.SelectedItem as MsSql.IdStringPair).Id;
                cargoData = (lstCargoData.SelectedItem as MsSql.IdStringPair).Text;
            }

            if (EditDialog.ExecuteDialog_Update(SelectedTable, id, cargoId, cargoType, cargoData) != "")
                RefreshListCargoData();
        }
        private void tbtnAddCargoData_Click(object sender, EventArgs e)
        {
            string cargoId = "";
            if (lstCargoId.SelectedItem != null)
                cargoId = (lstCargoId.SelectedItem as string);
            
            string cargoType = "";
            if (cmbCargoType.Text.Length ==3) 
                cargoType = cmbCargoType.Text;

            string addedCargoId = EditDialog.ExecuteDialog_Insert(SelectedTable, cargoId, cargoType);
            if (addedCargoId != "")
            {
                if (addedCargoId == cargoId)
                    RefreshListCargoData();
                else
                    RefreshListCargoId();
            }
        }
        private void tbtnDeleteCargoDataSingle_Click(object sender, EventArgs e)
        {
            if ((lstCargoId.SelectedItem != null) && (cmbCargoType.Text.Length == 3) && (lstCargoData.SelectedItem != null))
            {
                if (MessageBox.Show("Wollen Sie wirklich alle Einträge dieses cargo types löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSql.DeleteCargoSingle(SelectedTable, (lstCargoData.SelectedItem as MsSql.IdStringPair).Id);
                    RefreshListCargoData();
                }
            }
        }
        private void tbtnDeleteCargoDataType_Click(object sender, EventArgs e)
        {
            if ((lstCargoId.SelectedIndex != -1) && (cmbCargoType.Text.Length == 3))
            {
                if (MessageBox.Show("Wollen Sie wirklich alle Einträge in der Liste löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSql.DeleteCargoType(SelectedTable, (lstCargoId.SelectedItem as string), cmbCargoType.Text);
                    RefreshListCargoData();
                }
            }
        }
        private void tbtnRefreshCargoData_Click(object sender, EventArgs e)
        {
            RefreshListCargoData();
        }
        private void lstCargoData_DoubleClick(object sender, EventArgs e)
        {
            tbtnEditCargoData.PerformClick();
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbtnDropTable.Enabled = cmbTable.SelectedIndex != -1;

            RefreshListCargoId();
        }
        private void lstCargoId_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListCargoData();

            tbtnDeleteCargoId.Enabled = (lstCargoId.SelectedIndex != -1);
        }
        private void cmbCargoType_TextChanged(object sender, EventArgs e)
        {
            RefreshListCargoData();
        }
        private void lstCargoData_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbtnEditCargoData.Enabled = lstCargoData.SelectedItem != null;
            tbtnDeleteCargoDataSingle.Enabled = lstCargoData.SelectedItem != null;
        }
    }
}
