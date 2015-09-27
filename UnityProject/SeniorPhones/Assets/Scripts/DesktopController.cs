using UnityEngine;
using System.Collections;

public class DesktopController : ZBehaviour {

	public string inputX = "Horizontal";
	public string inputY = "Vertical";

	// Use this for initialization
	void Start () {
	
	}

    void Update() { }
	
	// Update is called once per frame
	void FixedUpdate () {

        float delta = 0.01f;
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
