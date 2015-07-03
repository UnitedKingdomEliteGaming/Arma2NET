using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAltisProjectDatabase
{
    public class IdStringPair
    {
        public Int64 Id;
        public string Text;

        public IdStringPair(Int64 id, string text)
        {
            Id = id;
            Text = text;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
