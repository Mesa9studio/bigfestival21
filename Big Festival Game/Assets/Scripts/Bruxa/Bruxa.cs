using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruxa : MonoBehaviour
{

           BruxaBaseState       currentState;
    public string               currentStateName;
    [Header("States")]
    public BruxaStoppedState        stoppedState        = new BruxaStoppedState();
    public BruxaMovementState       movementState       = new BruxaMovementState();
    public BruxaAttackState         attackState         = new BruxaAttackState();
    public BruxaFlyState            flyState            = new BruxaFlyState();
    public BruxaDamagedState        damagedState        = new BruxaDamagedState();
    public BruxaFlyingDamagedState  flyingDamagedState  = new BruxaFlyingDamagedState();
    public Rigidbody                myRb;
    public int                      life                = 1;


    // Start is called before the first frame update
    void Start()
    {
        // myRb.GetComponent<Rigidbody>();
        SwitchState(movementState);
    }


    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        FixedUpdateState();
    }


    public void SwitchState(BruxaBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
        currentStateName = state.GetStateName();
    }

    // atualiza o update do estado atual
    void UpdateState()
    {
        if (currentState != null)
            currentState.UpdateState(this);
    }

    // atualiza o fixedUpdate do estado atual
    void FixedUpdateState()
    {
        if (currentState != null)
            currentState.FixedUpdateState(this);
    }

    public void TakeDamage()
    {
        life--;
        currentState.TakeDamage(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter collision");
        currentState.OnCollisionEnter(this,collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Enter collision");
        currentState.OnCollisionEnter(this,collision);
    }

}
