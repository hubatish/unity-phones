using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ClientNetworkToolbox : MonoBehaviour {

	public static ClientNetworkToolbox Instance;

	// Use this for initialization
	void Awake () {
		Instance = this;
	}

	public NetworkMessenger GetNetworkMessenger(){
		return transform.parent.GetComponent<NetworkMessenger>();
	}
}
