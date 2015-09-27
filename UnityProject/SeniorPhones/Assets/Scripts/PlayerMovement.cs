using UnityEngine;
using System.Collections;

public class PlayerMovement : ZBehaviour {
	
	public float moveSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
    public void MoveInDirection(Vector2 direction)
    {
        Vector2 velocity = direction * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(velocity);
    }
}
