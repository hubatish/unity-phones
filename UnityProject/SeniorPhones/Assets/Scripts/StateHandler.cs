using UnityEngine;
using System.Collections;

public class StateHandler : MonoBehaviour {

    private int currentState;
    private int normal = 0;
    private int attack = 1;
    private int cooldown = 2;
    private int stun = 3;
    private int recovery = 4;
    private int severeStun = 5;

    [SerializeField] private float prevMoveSpeed = 0;
    private float stunDuration = 2f;
    private float recoveryDuration = 2f;
    private float cooldownDuration;
    private Server.PlayerMovement myMovement;

	// Use this for initialization
	void Start () {
        currentState = normal;
        cooldownDuration = stunDuration;
        myMovement =GetComponent<Server.PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Stun the player, Call Stunned Function
    public void StunPlayer()
    {
        if(currentState == normal || currentState == cooldown)
            StartCoroutine("Stunned");
        else if(currentState == attack)
            StartCoroutine("SeverelyStunned");
    }

    public void PlayerAttack(float duration)
    {
        if(currentState == normal)
            StartCoroutine("Attacking", duration);
    }

    private IEnumerator Attacking(float attackDuration)
    {
        currentState = attack;
        Debug.Log("I'm Attacking!");
        //Turn off attack button
        yield return new WaitForSeconds(attackDuration);
        if(currentState == attack)
            StartCoroutine("AttackCooldown");
    }


    private IEnumerator AttackCooldown()
    {
        currentState = cooldown;
        Debug.Log("I'm on Cooldown");
        //Attack button stays off
        yield return new WaitForSeconds(cooldownDuration);
        if(currentState == cooldown)
        {
            currentState = normal;
            //Turn on attack button
        }

    }

    //can't move, and wait
    private IEnumerator Stunned()
    {
        currentState = stun;
        Debug.Log("I'm Stunned!");
        StopPlayerMovement();
        yield return new WaitForSeconds(stunDuration);
        //CHANGE LAYER,CALL RECOVERY
        StartCoroutine("Recovering");
    }

    //Change to a different layer so can't be hit and wait, but can move now
    private IEnumerator Recovering()
    {
        currentState = recovery;
        Debug.Log("I'm in Recovery!");
        myMovement.SetMoveSpeed(prevMoveSpeed);
        yield return new WaitForSeconds(recoveryDuration);
        currentState = normal;
    }

    private IEnumerator SeverelyStunned()
    {
        currentState = severeStun;
        Debug.Log("I'm in Severely Stunned");
        StopPlayerMovement();
        yield return new WaitForSeconds(stunDuration * 1.5f);
        StartCoroutine("Recovering");

    }

    private void StopPlayerMovement()
    {
        prevMoveSpeed = (float) myMovement.GetMoveSpeed();
        myMovement.SetMoveSpeed(0f);
    }


}
