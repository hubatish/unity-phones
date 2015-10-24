using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Should be in a canvas
/// 
///     Is activated & deactivated by a larger button area underneath the joystick
/// </summary>
public class PhoneJoystick : MonoBehaviour {
    [SerializeField]
    protected Canvas canvas;

    [SerializeField]
    protected Transform joystickImage;

    NetworkMessenger playerMovement;

	void Start () {
        playerMovement = ClientNetworkToolbox.Instance.GetNetworkMessenger();
    }

    private int joystickTouch = 0;

	void Update () {
        bool pressed = false;
        Vector3 screenClickPos = Vector3.zero;
        if (Input.touchSupported)
        {
            //Support touches (multiple). 
            //  Always get the oldest touch, so if player is holding in multiple places will bug out
            if (Input.touchCount > 0)
            {
                pressed = true;
                screenClickPos = Input.GetTouch(0).position;
            }
        }
        else
        {
            //Just use mouse!
            pressed = Input.GetMouseButton(0);
            if (pressed)
            {
                screenClickPos = Input.mousePosition;
            }
        }
        if (pressed)
        {
            //get mouse pos in UI coordinates (from http://answers.unity3d.com/questions/849117/46-ui-image-follow-mouse-position.html)
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenClickPos, canvas.worldCamera, out pos);
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
            enabled = false;
        }
    }
}
