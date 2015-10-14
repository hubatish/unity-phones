using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Should be in a canvas
/// </summary>
public class PhoneJoystick : MonoBehaviour {

    [SerializeField]
    protected Canvas canvas;

    [SerializeField]
    protected Transform joystickImage;

    NetworkMessenger playerMovement;

	// Use this for initialization
	void Start () {
        playerMovement = ClientNetworkToolbox.Instance.GetNetworkMessenger();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            //get mouse pos in UI coordinates (from http://answers.unity3d.com/questions/849117/46-ui-image-follow-mouse-position.html)
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
            Vector3 dir = canvas.transform.TransformPoint(pos) - transform.position;
            dir = dir.normalized;
            joystickImage.position = transform.position + dir;
            if (playerMovement != null)
            {
                playerMovement.CmdMoveInDirection(dir);
            }
            //Debug.Log("Dir: " + dir);
        }
        else
        {
            joystickImage.position = transform.position;
            //enabled = false;
        }
    }
}
