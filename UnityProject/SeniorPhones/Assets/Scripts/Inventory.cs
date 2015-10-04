using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Inventory : NetworkBehaviour
{
    public GameObject item;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Command]
    public void CmdUseItem()
    {
        if (item != null)
        {
            Instantiate(item, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        }
    }

    public void RemoveItem()
    {
        item = null;
    }


}
