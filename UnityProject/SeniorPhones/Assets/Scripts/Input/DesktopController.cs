//Allows for arrow key usage
//Just for testing
using UnityEngine;
using System.Collections;
using Server;

public class DesktopController : ZBehaviour {

	public string inputX = "Horizontal";
	public string inputY = "Vertical";

	// Use this for initialization
	void Start () {
	}

    void Update() { }
    Vector3 prevPos;
	// Update is called once per frame
	void FixedUpdate () {

        float delta = 0f;
        if (Input.GetAxis(inputX) < -delta)
        {
            Cached<PlayerMovement>().MoveInDirection(Vector2.left);
        } else if (Input.GetAxis(inputX) > delta)
        {
            Cached<PlayerMovement>().MoveInDirection(Vector2.right);
        }

        if (Input.GetAxis(inputY) < -delta)
        {
            Cached<PlayerMovement>().MoveInDirection(Vector2.down);
        }else if (Input.GetAxis(inputY) > delta)
        {
            Cached<PlayerMovement>().MoveInDirection(Vector2.up);
        }
    }
}
