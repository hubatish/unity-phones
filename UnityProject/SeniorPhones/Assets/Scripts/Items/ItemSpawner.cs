using UnityEngine;
using System.Collections.Generic;

namespace Server
{
    public class ItemSpawner : MonoBehaviour
    {

        public Dictionary<ItemType, GameObject> dictionary;
        public List<GameObject> items;

        public static ItemSpawner Instance;

        private ItemSpawner() { }

        void Awake()
        {
            Instance = this;
        }

        // Use this for initialization
        void Start()
        {
            dictionary = new Dictionary<ItemType, GameObject>()
                        {
                            { ItemType.BlockItem, items[0] }
                        };
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Spawn(ItemType type, Vector3 position)
        {
            //TODO: Incorporate Direction
            Instantiate(dictionary[type], position, Quaternion.identity);
        }
    }
}