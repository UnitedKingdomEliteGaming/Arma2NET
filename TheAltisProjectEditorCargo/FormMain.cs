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

            cmbCargoType.SelectedIndex = 0;
            RefreshListCargoId();
        }

        private void tbtnReload_Click(object sender, EventArgs e)
        {
            RefreshListCargoId();
        }
        private void tbtnDeleteCargoId_Click(object sender, EventArgs e)
        {
            if (lstCargoId.SelectedIndex != -1)
            {
                if (MessageBox.Show("Wollen Sie wirklich alle Einträge dieser cargo id löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSql.DeleteCargoId((lstCargoId.SelectedItem as MsSql.IdStringPair).Text);
                    RefreshListCargoId();
                }
            }
        }
        private void tbtnDeleteCargoType_Click(object sender, EventArgs e)
        {
            if ((lstCargoId.SelectedIndex != -1) && (cmbCargoType.Text.Length == 3))
            {
                if (MessageBox.Show("Wollen Sie wirklich alle Einträge dieses cargo types löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSql.DeleteCargoType((lstCargoId.SelectedItem as  MsSql.IdStringPair).Text, cmbCargoType.Text);
                    RefreshListCargoData();
                }
            }
        }
        private void tbtnDeleteCargoSingle_Click(object sender, EventArgs e)
        {
            if ((lstCargoId.SelectedItem != null) && (cmbCargoType.Text.Length == 3) && (lstCargoData.SelectedItem != null))
            {
                if (MessageBox.Show("Wollen Sie wirklich alle Einträge dieses cargo types löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSql.DeleteCargoSingle((lstCargoData.SelectedItem as MsSql.IdStringPair).Id);
                    RefreshListCargoData();
                }
            }
        }
        private void tbtnEdit_Click(object sender, EventArgs e)
        {
            Int64 id = -1;
            string cargoId = "";
            if (lstCargoId.SelectedItem != null)
            {
                id = (lstCargoId.SelectedItem as MsSql.IdStringPair).Id;
                cargoId = (lstCargoId.SelectedItem as MsSql.IdStringPair).Text;
            }
            string cargoType = "";
            if (cmbCargoType.Text.Length == 3)
                cargoType = cmbCargoType.Text;

            string cargoData = "";
            if (lstCargoData.SelectedItem != null)
                cargoData = (lstCargoData.SelectedItem as MsSql.IdStringPair).Text;

            if (EditDialog.ExecuteDialog(id, cargoId, cargoType, cargoData, false) != "")
                RefreshListCargoData();
        }
        private void tbtnAdd_Click(object sender, EventArgs e)
        {
            Int64 id = -1;
            string cargoId = "";
            if (lstCargoId.SelectedItem != null)
            {
                id = (lstCargoId.SelectedItem as MsSql.IdStringPair).Id;
                cargoId = (lstCargoId.SelectedItem as MsSql.IdStringPair).Text;
            }
            string cargoType = "";
            if (cmbCargoType.Text.Length ==3) 
                cargoType = cmbCargoType.Text;

            string addedCargoId = EditDialog.ExecuteDialog(id, cargoId, cargoType, "", true);
            if (addedCargoId != "")
            {
                if (addedCargoId == cargoId)
                    RefreshListCargoData();
                else
                    RefreshListCargoId();
            }
        }

        private void lstCargoId_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListCargoData();

            tbtnDeleteCargoId.Enabled = (lstCargoId.SelectedIndex != -1);
        }
        private void cmbCargoType_TextChanged(object sender, EventArgs e)
        {
            tbtnDeleteCargoType.Enabled = cmbCargoType.Text.Length == 3;

            RefreshListCargoData();
        }
        private void lstCargoData_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbtnEdit.Enabled = lstCargoData.SelectedItem != null;
            tbtnDeleteCargoSingle.Enabled = lstCargoData.SelectedItem != null;
        }

        private void RefreshListCargoId()
        {
            MsSql.IdStringPair[] cargoIds = MsSql.GetCargoIds();
            lstCargoId.Items.Clear();
            foreach (MsSql.IdStringPair cargoId in cargoIds)
                lstCargoId.Items.Add(cargoId);

            RefreshListCargoData();
        }
        private void RefreshListCargoData()
        {
            lstCargoData.Items.Clear();
            if ((lstCargoId.SelectedItem != null) && (cmbCargoType.Text.Length == 3))
            {
                MsSql.IdStringPair[] cargoDatas = MsSql.GetCargoData((lstCargoId.SelectedItem as MsSql.IdStringPair).Text, cmbCargoType.Text);
                lstCargoData.Items.Clear();
                foreach (MsSql.IdStringPair cargoData in cargoDatas)
                    lstCargoData.Items.Add(cargoData);
            }
        }
    }
}
