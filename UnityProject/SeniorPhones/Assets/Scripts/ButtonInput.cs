using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ButtonInput : NetworkBehaviour {

	PlayerMovement playerMovement;
    Inventory inventory;

	// Use this for initialization
	void Start () {
		playerMovement = ClientNetworkToolbox.Instance.GetNetworkMover();
        inventory = ClientNetworkToolbox.Instance.GetInventory();
	}

	public void MoveRight ()
	{
		playerMovement.CmdMoveInDirection(Vector2.right);
	}

	public void MoveLeft()
	{
		playerMovement.CmdMoveInDirection(Vector2.left);
	}

	public void MoveUp()
	{
		playerMovement.CmdMoveInDirection(Vector2.up);
	}

	public void MoveDown()
	{
		playerMovement.CmdMoveInDirection(Vector2.down);
	}

    public void Attack()
    {
        Debug.Log("ATTCKING");
        inventory.CmdUseItem();
    }
}
