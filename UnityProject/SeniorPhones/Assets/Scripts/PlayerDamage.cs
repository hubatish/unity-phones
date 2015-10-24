using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
    public float TimeBlinking = 0.5f;
    float blinkTime;
    Renderer myRenderer;
	// Use this for initialization
	void Start () {
        myRenderer = GetComponent<Renderer>();
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
        //For immediate testing concerns, the state handler call is placed below
        //Later, it will only be called upon being hit
        //
        if(coll.gameObject.tag == "Item")
        {
            blinkTime = TimeBlinking;
            GetComponent<StateHandler>().StunPlayer();
        }
    }
}
