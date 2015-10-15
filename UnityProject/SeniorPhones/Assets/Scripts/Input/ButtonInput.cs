//In Client scene, UI buttons call these functions
//Passes these functions onto server middle man
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ButtonInput : MonoBehaviour {

	NetworkMessenger networker;

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
        networker.CmdUseItem(0);

        Debug.Log("ATTCKING");
        //inventory.UseItem(0);

    }
}
