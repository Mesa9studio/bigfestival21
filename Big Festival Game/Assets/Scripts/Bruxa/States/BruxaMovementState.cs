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
        Debug.Log($"Entrando no estado -> {GetStateName()}");
        bruxa.bruxaAnimator.Play("walk");
    }


    // Update
    public override void UpdateState(Bruxa bruxa)
    {
        // Debug.Log(GetStateName());
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown((int)(bruxa.flyState.flyMouseButton)))
        {
            bruxa.SwitchState(bruxa.flyState);
        }

        if(movement.magnitude == 0)
        {
            bruxa.SwitchState(bruxa.stoppedState);
        }
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
        Debug.Log($"O colisor de {GetStateName()} entrou");

    }


    // verifica quando o colisor saiu
    public override void OnCollisionExit(Bruxa bruxa, Collision collision)
    {
        Debug.Log($"O colisor de {GetStateName()} saiu");
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
