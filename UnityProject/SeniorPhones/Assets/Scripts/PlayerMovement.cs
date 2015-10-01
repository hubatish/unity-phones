using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMovement : NetworkBehaviour {
	
	public float moveSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
    [Command]
    public void CmdMoveInDirection(Vector2 direction)
    {
        Vector2 velocity = direction * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(velocity);
    }
}
