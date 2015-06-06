using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Arma2NetSimulator
{
    public partial class FormMain : Form
    {

        [DllImport("Arma2Net.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void RVExtension(StringBuilder output, int outputSize, string function);

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            StringBuilder output = new StringBuilder(4096);
            RVExtension(output, output.MaxCapacity, cmbCommand.Text);

            lstResult.Items.Add("Execute: " + cmbCommand.Text);
            lstResult.Items.Add("-Result: " + output.ToString());
            lstResult.SelectedIndex = lstResult.Items.Count - 1;
        }
    }
}
