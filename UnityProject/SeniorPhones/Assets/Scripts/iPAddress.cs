using UnityEngine;
using System.Collections;

public class iPAddress : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject ipAddress = gameObject;
        ipAddress.AddComponent<GUIText>();
        ipAddress.transform.position = new Vector3(0.5f, 0.9f, 0.0f);
        ipAddress.GetComponent<GUIText>().text = "IP Address: " + Network.player.ipAddress;
    }
}
