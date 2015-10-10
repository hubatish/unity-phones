//The actual movement of the player within the scene
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMovement : NetworkBehaviour {
	
	private float moveSpeed = 2.0f;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
    [Command]
    public void CmdMoveInDirection(Vector2 direction)
    {
        Vector2 velocity = direction * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(velocity);
    }
}
