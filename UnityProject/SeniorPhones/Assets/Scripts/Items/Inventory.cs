using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class Inventory
    {
        private static Inventory _inv;
        public static Inventory Instance { get
            {
                if (_inv == null) _inv = new Inventory();
                return _inv;
            }
        }

        private List<ItemType> items;
        public SpriteRenderer attackButtonSprite;

        private Inventory()
        {
            items = new List<ItemType> { ItemType.BlockItem };
            UpdateSprite();
        }
        
        public void AddItem(ItemType item)
        {
            items.Add(item);
            UpdateSprite();
        }

        public void UseItem(int index)
        {
            if (items.Count > 0)
            {
                UpdateSprite();
                items.RemoveAt(0);
            }
        }

        public void RemoveItem()
        {
            if (items.Count > 0)
            {
                items.RemoveAt(0);
            }
        }

        private void UpdateSprite()
        {
           /* if(items.Count >= 1)
            {
                attackButtonSprite.sprite = null;
            } */
        }

    }

}

