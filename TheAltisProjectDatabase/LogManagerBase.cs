using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAltisProjectDatabase
{
    public abstract class LogManagerBase
    {
        public abstract void  Info(string text);
        public abstract void Info(string text, string param1);
        public abstract void Error(string text);
        public abstract void Error(string text, string param1);
    }
}
