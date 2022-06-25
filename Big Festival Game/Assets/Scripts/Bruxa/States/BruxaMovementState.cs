using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class BruxaMovementState : BruxaBaseState
{
    public float movementSpeed;

    // Start
    public override void EnterState(Bruxa bruxa)
    {
        Debug.Log($"Entrando no estado -> {GetStateName()}");
    }


    // Update
    public override void UpdateState(Bruxa bruxa)
    {
        // Debug.Log(GetStateName());

        if (Input.GetKey(bruxa.flyState.flyUp))
        {
            bruxa.SwitchState(bruxa.flyState);
        }
    }


    // FixedUpdate
    public override void FixedUpdateState(Bruxa bruxa)
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));

        if(movement.magnitude != 0)
            movement /= movement.magnitude; // mantem a velocididade na diagonal igual na vertical e horizontal

        bruxa.myRb.MovePosition(bruxa.transform.position + movement * Time.deltaTime * movementSpeed);
    }


    // verifica quando o colisor entrou
    public override void OnCollisionEnter(Bruxa bruxa, Collision collision)
    {
        Debug.Log($"O colisor de {GetStateName()} entrou");
        if(collision.gameObject.tag == "Inimigo")
            bruxa.TakeDamage();
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
