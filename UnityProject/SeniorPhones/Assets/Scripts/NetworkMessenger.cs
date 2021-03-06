﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using Server;

/// <summary>
/// Handle all messages from client to server
///     Er.. that's too much, but for now it's fine
/// </summary>
public class NetworkMessenger : NetworkBehaviour
{
    public Server.PlayerMovement playerMovement;

    protected void Awake()
    {
    }

    public void InitializeOnClient()
    {

    }

    public void InitializeOnServer()
    {
        playerMovement = gameObject.GetComponentInChildren<Server.PlayerMovement>();
    }

    [Command]
    public void CmdMoveInDirection(Vector2 direction)
    {
        playerMovement.MoveInDirection(direction);
        /*Vector2 velocity = direction * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(velocity);*/
    }

    [Command]
    public void CmdUseItem(ItemType item)
    {
        Debug.Log("Using item : " + item);
        ItemSpawner.Instance.Spawn(item, playerMovement.transform.position + new Vector3(1, 0, 0));
    }

    [ClientRpc]
    public void RpcAddItem(ItemType item)
    {
        Client.Inventory.Instance.AddItem(item);
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
