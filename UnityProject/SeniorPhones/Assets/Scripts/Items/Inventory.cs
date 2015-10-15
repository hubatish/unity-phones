using System.Collections.Generic;
using UnityEngine;

namespace Server
{

    public class Inventory : MonoBehaviour
    {
        public List<AbstractItem> playerItems;

        // Use this for initialization
        void Start()
        {
            playerItems = new List<AbstractItem>();
            playerItems.Add(new BlockItem());
        }

        // Update is called once per frame
        void Update()
        {
        }


        public void AddItem(AbstractItem item)
        {
            playerItems.Add(item);
        }

        public void UseItem(int index)
        {
            if (index >= 0 && index < playerItems.Count)
            {
                playerItems[index].Use(transform.position);
                playerItems.RemoveAt(index);
            }
        }

    }

}

