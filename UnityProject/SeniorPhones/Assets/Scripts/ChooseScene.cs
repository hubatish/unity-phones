using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ChooseScene : NetworkBehaviour {

    public Transform player;
    public Transform client;

	// Use this for initialization
	void Start () {
        if (!isServer)
        {
            if(isLocalPlayer)
            {
                Transform spawnedClient = (Transform)GameObject.Instantiate(client, transform.position, Quaternion.identity);
                spawnedClient.parent = transform;
                DontDestroyOnLoad(gameObject);
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
        else
        {
            Transform spawnedPlayer = (Transform)GameObject.Instantiate(player, transform.position, Quaternion.identity);
            spawnedPlayer.parent = transform;
        }
	}
}
