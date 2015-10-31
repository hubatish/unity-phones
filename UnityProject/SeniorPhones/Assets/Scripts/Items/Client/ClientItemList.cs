using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Client
{

    public class ClientItemList : MonoBehaviour
    {

        public static ClientItemList Instance;
        public List<Item> itemList;
        private Dictionary<ItemType, Item> itemDictionary;


        // Use this for initialization
        void Awake()
        {
            Instance = this;
        }


        // Use this for initialization
        void Start()
        {
            itemDictionary = itemList.ToDictionary(x => x.itemType);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public Item GetItem(ItemType item)
        {
            return itemDictionary[item];
        }
    }
}
