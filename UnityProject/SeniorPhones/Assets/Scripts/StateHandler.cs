using UnityEngine;
using System.Collections;

public class StateHandler : MonoBehaviour {

    enum State{Normal, Attack, Cooldown, Stun, Recovery, SevereStun};
    private State currentState;
    private NetworkMessenger networker;

    [SerializeField] private float prevMoveSpeed = 0;
    private float stunDuration = 2f;
    private float recoveryDuration = 2f;
    private float cooldownDuration;
    private Server.PlayerMovement myMovement;
    private SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () {
        currentState = State.Normal;
        cooldownDuration = stunDuration;
        myMovement =GetComponent<Server.PlayerMovement>();
        myRenderer = GetComponent<SpriteRenderer>();
        networker = transform.parent.GetComponent<NetworkMessenger>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Stun the player, Call Stunned Function
    public void StunPlayer()
    {
        if(currentState == State.Normal || currentState == State.Cooldown)
            StartCoroutine("Stunned");
        else if(currentState == State.Attack)
            StartCoroutine("SeverelyStunned");
    }

    public void PlayerAttack(float duration)
    {
        if(currentState == State.Normal)
            StartCoroutine("Attacking", duration);
    }

    private IEnumerator Attacking(float attackDuration)
    {
        currentState = State.Attack;
        //Debug.Log("I'm Attacking!");
        //Turn off attack button
        networker.RpcDisableButton("AttackButton");
        SetPlayerColor(Color.red);
        StopPlayerMovement();
        yield return new WaitForSeconds(attackDuration);
        if(currentState == State.Attack)
            StartCoroutine("AttackCooldown");
    }


    private IEnumerator AttackCooldown()
    {
        currentState = State.Cooldown;
        //Debug.Log("I'm on Cooldown");
        //Attack button stays off
        myMovement.SetMoveSpeed(prevMoveSpeed);
        SetPlayerColor(Color.blue);
        yield return new WaitForSeconds(cooldownDuration);
        if(currentState == State.Cooldown)
        {
            ReturnPlayerToNormal();
            //Turn on attack button
        }

    }

    //can't move, and wait
    private IEnumerator Stunned()
    {
        currentState = State.Stun;
        //Debug.Log("I'm Stunned!");
        StopPlayerMovement();
        networker.RpcDisableButton("AttackButton");
        SetPlayerColor(Color.yellow);
        yield return new WaitForSeconds(stunDuration);
        //CHANGE LAYER,CALL RECOVERY
        StartCoroutine("Recovering");
    }

    //Change to a different layer so can't be hit and wait, but can move now
    private IEnumerator Recovering()
    {
        currentState = State.Recovery;
        //Debug.Log("I'm in Recovery!");
        myMovement.SetMoveSpeed(prevMoveSpeed);
        SetPlayerColor(Color.green);
        yield return new WaitForSeconds(recoveryDuration);
        //currentState = State.Normal;
        ReturnPlayerToNormal();
    }

    private IEnumerator SeverelyStunned()
    {
        currentState = State.SevereStun;
        //Debug.Log("I'm in Severely Stunned");
        StopPlayerMovement();
        networker.RpcDisableButton("AttackButton");
        SetPlayerColor(Color.magenta);
        yield return new WaitForSeconds(stunDuration * 1.5f);
        StartCoroutine("Recovering");

    }

    private void StopPlayerMovement()
    {
        prevMoveSpeed = (float) myMovement.GetMoveSpeed();
        myMovement.SetMoveSpeed(0f);
    }

    private void SetPlayerColor(Color c)
    {
        myRenderer.color = c;
    }

    private void ReturnPlayerToNormal()
    {
        currentState = State.Normal;
        SetPlayerColor(Color.white);
        networker.RpcEnableButton("AttackButton");
    }

}
