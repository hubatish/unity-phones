using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Server
{
    public class Inventory : MonoBehaviour
    {
        public GameObject item;
        private StateHandler playerState;

        void Start()
        {
            playerState = GetComponent<StateHandler>();
        }

        public void UseItem()
        {
            if (item != null)
            {
                Instantiate(item, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                playerState.PlayerAttack(item.GetComponent<ItemInformation>().attackDuration);
            }
        }

        public void RemoveItem()
        {
            item = null;
        }
    }
}

