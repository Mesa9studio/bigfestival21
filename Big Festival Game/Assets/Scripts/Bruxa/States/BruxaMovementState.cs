using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class BruxaMovementState : BruxaBaseState
{
    public float movementSpeed;
    public Vector3 movement;

    // Start
    public override void EnterState(Bruxa bruxa)
    {
        bruxa.bruxaAnimator.Play("walk");
    }


    // Update
    public override void UpdateState(Bruxa bruxa)
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        bruxa.SwitchState(bruxa.attackState, Input.GetAxis("Ataque") != 0);
        bruxa.SwitchState(bruxa.flyState, Input.GetAxis("Fly") > 0 && bruxa.flyState.flyFuel > 0);
        bruxa.SwitchState(bruxa.stoppedState, movement.magnitude == 0);
    }


    // FixedUpdate
    public override void FixedUpdateState(Bruxa bruxa)
    {


        if(movement.magnitude != 0)
            movement /= movement.magnitude; // mantem a velocididade na diagonal igual na vertical e horizontal

        bruxa.myRb.MovePosition(bruxa.transform.position + movement * Time.deltaTime * movementSpeed);
        bruxa.transform.rotation = Quaternion.LookRotation(movement);
    }


    // verifica quando o colisor entrou
    public override void OnCollisionEnter(Bruxa bruxa, Collision collision)
    {

    }


    // verifica quando o colisor saiu
    public override void OnCollisionExit(Bruxa bruxa, Collision collision)
    {
    }


    public override void OnTriggerEnter(Bruxa bruxa, Collider collider)
    {
        
    }


    public override void OnTriggerExit(Bruxa bruxa, Collider collider)
    {

    }


    // retorna o nome do estado que no caso é o nome desse script
    public override string GetStateName()
    {
        return this.GetType().ToString();
    }


    public override void TakeDamage(Bruxa bruxa)
    {
        bruxa.SwitchState(bruxa.damagedState);
    }
}
