using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class BruxaStoppedState : BruxaBaseState
{
    // Start
    public override void EnterState(Bruxa bruxa)
    {
        Debug.Log($"Entrando no estado -> {GetStateName()}");
    }


    // Update
    public override void UpdateState(Bruxa bruxa)
    {
        // Debug.Log(GetStateName());
        if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            bruxa.SwitchState(bruxa.movementState);
        }
    }


    // FixedUpdate
    public override void FixedUpdateState(Bruxa bruxa)
    {
        // Debug.Log(GetStateName());
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
