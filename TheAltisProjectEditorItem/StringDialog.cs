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
    public partial class StringDialog : Form
    {
        private StringDialog()
        {
            InitializeComponent();
        }

        public static string ExecuteDialog(string title, string description, string text)
        {
            using (StringDialog dlg = new StringDialog())
            {
                dlg.Text = title;
                dlg.lblDescription.Text = description;
                dlg.txtText.Text = text;

                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.txtText.Text;
                else
                    return null;
            }
        }
    }
}
