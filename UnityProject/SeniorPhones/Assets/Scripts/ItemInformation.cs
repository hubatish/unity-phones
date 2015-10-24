using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ItemInformation : MonoBehaviour {
    public float attackDuration;

	// Use this for initialization
	void Start () {
        Destroy(gameObject,attackDuration);
	}
	
	// Update is called once per frame
	void Update () {
	}

}
