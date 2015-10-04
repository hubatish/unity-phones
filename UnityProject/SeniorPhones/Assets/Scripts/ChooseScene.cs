using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Net;

public class ChooseScene : NetworkBehaviour
{

    public Transform player;
    public Transform client;

    // Use this for initialization
    void Start()
    {
        if (!isServer)
        {
            if (isLocalPlayer)
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

            GameObject ipAddress = new GameObject();
            ipAddress.AddComponent<GUIText>();
            ipAddress.transform.position = new Vector3(0.5f, 0.9f, 0.0f);
            ipAddress.GetComponent<GUIText>().text = "IP Address: " + Network.player.ipAddress;
        }
    }
}
