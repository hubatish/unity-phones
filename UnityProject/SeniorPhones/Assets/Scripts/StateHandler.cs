using UnityEngine;
using System.Collections;

public class StateHandler : MonoBehaviour {

    private int currentState;
    private int normal = 0;
    private int attacking = 1;
    private int stun = 2;
    private int recovery = 3;

    [SerializeField] private float prevMoveSpeed = 0;
    private PlayerMovement myMovement;

	// Use this for initialization
	void Start () {
        currentState = normal;
        myMovement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Stun the player, Call Stunned Function
    public void StunPlayer(){
        if(currentState < 2)
            StartCoroutine("Stunned");
    }

    //Change layers, can't move, and wait
    private IEnumerator Stunned(){
        currentState = stun;
        Debug.Log("I'm Stunned!");
        prevMoveSpeed = (float) myMovement.getMoveSpeed();
        myMovement.setMoveSpeed(0f);
        yield return new WaitForSeconds(2);
        //CHANGE LAYER,CALL RECOVERY
        StartCoroutine("Recovering");
    }

    //Change to a different layer and wait, but can move now
    public IEnumerator Recovering(){
        currentState = recovery;
        Debug.Log("I'm in Recovery!");
        myMovement.setMoveSpeed(prevMoveSpeed);
        yield return new WaitForSeconds(2);
        currentState = normal;
    }
}
