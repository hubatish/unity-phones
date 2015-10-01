using UnityEngine;
using System.Collections;

public class ButtonInput : MonoBehaviour {

	PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
		playerMovement = ClientNetworkToolbox.Instance.GetNetworkMover();
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
}
