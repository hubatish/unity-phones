using UnityEngine;
using System.Collections;

public class BlockItem : AbstractItem {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    public override void Use (Vector3 position) {
        //TODO: pass in direction of player
        Instantiate(gameObject, position + new Vector3(1, 0, 0), Quaternion.identity);
    }


}
