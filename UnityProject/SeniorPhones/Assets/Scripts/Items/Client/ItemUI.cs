using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Client {

    public class ItemUI : MonoBehaviour {

        private List<Item> items = new List<Item>(Inventory.MaxItemCount);
        public List<Image> uiItems = new List<Image>(Inventory.MaxItemCount);
        public static ItemUI Instance;

        // Use this for initialization
        void Awake()
        {
            Instance = this;
            Inventory.Instance.OnItemAdd += AddItemHandler;
            Inventory.Instance.OnItemRemoval += RemoveItemHandler;
        }

        void Start()
        {
            Inventory.Instance.AddItem(ItemType.BlockItem);
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

        public Item GetItem(int index)
        {
            return items[index];
        }
    }
}
