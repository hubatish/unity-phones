﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkMessenger : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CmdMove();
	}

    [Command]
    void CmdMove()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }
}