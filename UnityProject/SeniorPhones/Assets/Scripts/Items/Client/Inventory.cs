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

        public int Count { get { return items.Count; } }

        private List<ItemType> items;
        public static int MaxItemCount;

        private Inventory()
        {
            items = new List<ItemType>();
        }
        
        public void AddItem(ItemType item)
        {
            items.Add(item);

            if(OnItemAdd != null)
            {
                OnItemAdd(ClientItemList.Instance.GetItem(item));
            }
        }

        public Item GetItem(int index)
        {
            if (items.Count > index)
            {
                return ClientItemList.Instance.GetItem(items[index]);
            }
            else
            {
                return null;
            }
        }

        public void RemoveItem(int index)
        {
            if (items.Count > 0)
            {
                if (OnItemRemoval != null)
                {
                    OnItemRemoval(ClientItemList.Instance.GetItem(items[index]));
                }

                items.RemoveAt(index);
            }
        }

    }

}

