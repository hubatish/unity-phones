﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Handle all messages from client to server
///     Er.. that's too much, but for now it's fine
/// </summary>
public class NetworkMessenger : NetworkBehaviour
{
    public Server.PlayerMovement playerMovement;
    public Server.Inventory inventory;

    protected void Awake()
    {
    }

    public void InitializeOnClient()
    {

    }

    public void InitializeOnServer()
    {
        playerMovement = gameObject.GetComponentInChildren<Server.PlayerMovement>();
        inventory = gameObject.GetComponentInChildren<Server.Inventory>();
    }

    [Command]
    public void CmdMoveInDirection(Vector2 direction)
    {
        playerMovement.MoveInDirection(direction);
        /*Vector2 velocity = direction * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(velocity);*/
    }

    [Command]
    public void CmdUseItem()
    {
        inventory.UseItem();
    }

    [ClientRpc]
    public void  RpcDisableButton(string buttonName)
    {
        Button aButton = GameObject.Find(buttonName).GetComponent<Button>();
        aButton.interactable = false;
    }
    [ClientRpc]
    public void RpcEnableButton(string buttonName)
    {
        Button aButton = GameObject.Find(buttonName).GetComponent<Button>();
        aButton.interactable = true; 
    }

}
