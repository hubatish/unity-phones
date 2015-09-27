using UnityEngine;
using System.Collections;

public class PlayerMovement : ZBehaviour {
	
	public float moveSpeed = 2.0f;
    private float slideTime = 0.0000000000000000000000000000000000000000000000000000000000000001f;
    public float currentlyMoving = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (currentlyMoving > 0)
        {
            currentlyMoving -= Time.deltaTime;
        }
        else
        {
            Cached<Rigidbody2D>().velocity = Vector2.zero;
        }
	}

    public void MoveInDirection(Vector2 direction)
    {
        Cached<Rigidbody2D>().MovePosition(Cached<Rigidbody2D>().position + direction*moveSpeed*Time.fixedDeltaTime);
        currentlyMoving = slideTime;
    }
}
