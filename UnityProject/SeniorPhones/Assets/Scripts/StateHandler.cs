using UnityEngine;
using System.Collections;

public class StateHandler : MonoBehaviour {

    private int CurrentState;
    //0 = normal
    //1 = stunned
    //2 = recovery
    //3 = attacking

	// Use this for initialization
	void Start () {
        CurrentState = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Stun the player, Call Stunned Function
    public void StunPlayer(){
        StartCoroutine("Stunned");
    }

    //Change layers, can't move, and wait
    private IEnumerator Stunned(){
        CurrentState = 1;
        GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2);
        //CHANGE LAYER,CALL RECOVERY
        Debug.Log("I'm in Stunned!");
        StartCoroutine("Recovering");
    }

    //Change to a different layer and wait, but can move now
    public IEnumerator Recovering(){
        CurrentState = 2;
        GetComponent<PlayerMovement>().enabled = true;
        yield return new WaitForSeconds(2);
        Debug.Log("I'm in Recovery!");
    }
}
