﻿//In Client scene, UI buttons call these functions
//Passes these functions onto server middle man
using UnityEngine;
using Client;

public class ButtonInput : MonoBehaviour {

	NetworkMessenger networker;
    public GameObject inventoryUI;

	// Use this for initialization
	void Start () {
		networker = ClientNetworkToolbox.Instance.GetNetworkMessenger();
	}

	public void MoveRight ()
	{
		networker.CmdMoveInDirection(Vector2.right);
	}

	public void MoveLeft()
	{
		networker.CmdMoveInDirection(Vector2.left);
	}

	public void MoveUp()
	{
		networker.CmdMoveInDirection(Vector2.up);
	}

	public void MoveDown()
	{
		networker.CmdMoveInDirection(Vector2.down);
	}

    public void Attack()
    {
        Inventory.Instance.UseItem(0);
        networker.CmdUseItem(0);

        Debug.Log("ATTCKING");
    }

    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
    }
}
