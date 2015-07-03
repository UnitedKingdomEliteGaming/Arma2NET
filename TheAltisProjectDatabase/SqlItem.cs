using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAltisProjectDatabase
{
    public class SqlItem
    {
        public Int64 Id;
        public string ItemId;
        public string ItemData;

        public SqlItem(Int64 id, string itemId, string itemData)
        {
            Id = id;
            ItemId = itemId;
            ItemData = itemData;
        }
        public override string ToString()
        {
            return ItemId;
        }
    }
}