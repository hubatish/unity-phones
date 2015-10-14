using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Net;

public class SceneChooser : NetworkBehaviour
{
    public Transform player;
    public Transform client;

    public NetworkMessenger networker;

    // Use this for initialization
    void Start()
    {
        networker = gameObject.GetComponent<NetworkMessenger>();
        if (!isServer)
        {
            if (isLocalPlayer)
            {
                Transform spawnedClient = (Transform)GameObject.Instantiate(client, transform.position, Quaternion.identity);
                spawnedClient.parent = transform;
                DontDestroyOnLoad(gameObject);
                Application.LoadLevel("clientScene");
                networker.InitializeOnClient();
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
        }
        else
        {
            Transform spawnedPlayer = (Transform)GameObject.Instantiate(player, transform.position, Quaternion.identity);
            spawnedPlayer.parent = transform;
            networker.InitializeOnServer();
            if (isLocalPlayer)
            {
                //if we are the server and spawned a local client, use this as a tester
                //TO DO:
                //Make sure the compoenent goes on correct game object, possibly the child
                gameObject.AddComponent<DesktopController>();
            }
        }
    }
}
