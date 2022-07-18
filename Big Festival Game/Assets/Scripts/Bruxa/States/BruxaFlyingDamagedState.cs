using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class BruxaFlyingDamagedState : BruxaBaseState
{
    // Start
    public override void EnterState(Bruxa bruxa)
    {
        Debug.Log($"Entrando no estado -> {GetStateName()}");
        bruxa.bruxaAnimator.Play("hit fly");
    }


    // Update
    public override void UpdateState(Bruxa bruxa)
    {
        // Debug.Log(GetStateName());
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
        //TODO
    }
}
