using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Client
{
    public class Inventory
    {
        private static Inventory _inv;

        public delegate void AddItemHandler(Item item);
        public event AddItemHandler OnItemAdd;

        public delegate void RemoveItemHandler(Item item);
        public event RemoveItemHandler OnItemRemoval;

        public static Inventory Instance { get
            {
                if (_inv == null) _inv = new Inventory();
                return _inv;
            }
        }

        private List<ItemType> items;
        public static int MaxItemCount;

        private Inventory()
        {
            items = new List<ItemType> { ItemType.BlockItem };
        }
        
        public void AddItem(ItemType item)
        {
            items.Add(item);

            if(OnItemAdd != null)
            {
                OnItemAdd(ClientItemList.Instance.GetItem(item));
            }
        }

        public List<Item> GetItems()
        {
           return items.Select(x => ClientItemList.Instance.GetItem(x)).ToList();
        }

        public void UseItem(int index)
        {
            if (items.Count > 0)
            {
                items.RemoveAt(0);

                if (OnItemRemoval != null)
                {
                    OnItemAdd(ClientItemList.Instance.GetItem(items[index]));
                }
            }
        }

        public void RemoveItem()
        {
            if (items.Count > 0)
            {
                items.RemoveAt(0);

                if (OnItemRemoval != null)
                {
                    OnItemAdd(ClientItemList.Instance.GetItem(items[0]));
                }
            }
        }

    }

}

