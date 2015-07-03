using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAltisProjectEditorCargo
{
    class LogManager : TheAltisProjectDatabase.LogManagerBase
    {
        public override void Info(string text)
        {
            System.Windows.Forms.MessageBox.Show(text);
        }

        public override void Info(string text, string param1)
        {
            System.Windows.Forms.MessageBox.Show(string.Format(text, param1));
        }

        public override void Error(string text)
        {
            System.Windows.Forms.MessageBox.Show(text);
        }

        public override void Error(string text, string param1)
        {
            System.Windows.Forms.MessageBox.Show(string.Format(text, param1));
        }
    }
}
