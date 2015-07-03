using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAltisProjectAddin
{
    class LogManager: TheAltisProjectDatabase.LogManagerBase
    {
        public override void Info(string text)
        {
            Arma2Net.Utils.Log(text);
        }

        public override void Info(string text, string param1)
        {
            Arma2Net.Utils.Log(text, param1);
        }

        public override void Error(string text)
        {
            Arma2Net.Utils.Log(text);
        }

        public override void Error(string text, string param1)
        {
            Arma2Net.Utils.Log(text, param1);
        }
    }
}
