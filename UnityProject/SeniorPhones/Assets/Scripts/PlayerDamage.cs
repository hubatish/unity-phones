using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
    public float TimeBlinking = 0.5f;
    float blinkTime;
    Renderer myRenderer;
	// Use this for initialization
	void Start () {
        myRenderer = GetComponentInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(blinkTime >= 0)
        {
            blinkTime -= Time.deltaTime;

            myRenderer.enabled = !myRenderer.enabled;
            
            if(blinkTime <= 0)
            {
                myRenderer.enabled = true;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("COLLISIONING");

        if(coll.gameObject.tag == "Item")
        {
            blinkTime = TimeBlinking;
            GetComponent<StateHandler>().StunPlayer();
        }
    }
}
