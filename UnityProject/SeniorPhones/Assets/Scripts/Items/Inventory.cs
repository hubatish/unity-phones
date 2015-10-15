using System.Collections.Generic;
using UnityEngine;

namespace Server
{
    public enum ItemType { BlockItem };

    public class Inventory : MonoBehaviour
    {
        private List<ItemType> items;

        // Use this for initialization
        void Start()
        {
            items = new List<ItemType> { ItemType.BlockItem };
        }

        // Update is called once per frame
        void Update()
        {
        }
        
        public void AddItem(ItemType item)
        {
            items.Add(item);
        }

        public void UseItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                ItemSpawner.Instance.Spawn(items[index], transform.position + Vector3.right);
                items.RemoveAt(index);
            }
        }

    }

}

