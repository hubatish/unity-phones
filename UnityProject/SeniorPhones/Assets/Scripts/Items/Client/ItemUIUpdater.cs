using UnityEngine;
using System.Collections.Generic;

namespace Client {

    public class ItemUIUpdater : MonoBehaviour {

        public List<Item> items = new List<Item>(Inventory.MaxItemCount);
        public List<SpriteRenderer> uiItems = new List<SpriteRenderer>(Inventory.MaxItemCount);

        // Use this for initialization
        void Awake()
        {
        }

        void Start()
        {
            Inventory.Instance.OnItemAdd += AddItemHandler;
        }

        private void AddItemHandler(Item item)
        {
            items.Add(item);
            uiItems[items.Count - 1].sprite = items[items.Count - 1].ItemSprite;
        }
        
        private void RemoveItemHandler(Item item)
        {
            items.Remove(item);

            int i = 0;

            for(; i < uiItems.Count; i++)
            {
                if(uiItems[i].sprite == item.ItemSprite) { uiItems[i].sprite = null; break; }
            }

            for(; i < uiItems.Count-1; i++)
            {
                uiItems[i].sprite = uiItems[i + 1].sprite;
            }

            uiItems[i].sprite = null;
        }
    }
}
