using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Server
{
    public class Inventory : ZBehaviour
    {
        public GameObject item;
        private StateHandler playerState;
        private float attackDistance = 1f;

        void Start()
        {
            playerState = GetComponent<StateHandler>();
        }

        public void UseItem()
        {
            if (item != null)
            {
                Vector2 dir = Cached<PlayerMovement>().GetPreviousDirection();
                Instantiate(item, transform.position + (Vector3)dir * attackDistance, Quaternion.identity);
                playerState.PlayerAttack(item.GetComponent<ItemInformation>().attackDuration);
            }
        }

        public void RemoveItem()
        {
            item = null;
        }
    }
}

