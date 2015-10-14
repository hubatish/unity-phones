using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class HoldButon : ZBehaviour
{

    NetworkMessenger playerMovement;

    // Use this for initialization
    void Start()
    {
        playerMovement = ClientNetworkToolbox.Instance.GetNetworkMessenger();
    }

    [SerializeField]
    protected Vector2 dir;

    protected void Update()
    {
        if (Input.GetMouseButton(0))
        {
            playerMovement.CmdMoveInDirection(dir);
        }
    }
}
