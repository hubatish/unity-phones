using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class ItemInfoHelper
    {
        private Dictionary<ItemType, ItemInfo> itemList;

        public ItemInfoHelper() {
            itemList = new Dictionary<ItemType, ItemInfo>
            {

            };
        }

    }
}
