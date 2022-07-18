using System.Diagnostics.Tracing;
using System.Collections.ObjectModel;
using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class BruxaAttackState : BruxaBaseState
{
    public float damageValue=1f;

    // Start
    public override void EnterState(Bruxa bruxa)
    {
        Debug.Log($"Entrando no estado -> {GetStateName()}");
        bruxa.bruxaAnimator.Play("attack");
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
        // Debug.Log($"Name: {collision.gameObject.name}");
    }


    // verifica quando o colisor saiu
    public override void OnCollisionExit(Bruxa bruxa, Collision collision)
    {
        // Debug.Log($"O colisor de {GetStateName()} saiu");
    }


    public override void OnTriggerEnter(Bruxa bruxa, Collider collider)
    {
        Debug.Log($"Eu acertei o colisor de -> {collider.gameObject.name}");
        if(collider.tag == Tags.Zombie)
        {
            Debug.Log("Zumbi recebeu dano e agora deve ficar tonto");
            //TODO
        }
        if(collider.tag == Tags.NecromanticShoot)
        {
            Debug.Log("Acertei a bola de fogo do necromance e agora ela deve voltar para ele");
            //TODO
        }
    }


    public override void OnTriggerExit(Bruxa bruxa, Collider collider)
    {
        Debug.Log($"Eu acertei e sai do colisor de -> {collider.gameObject.name}");
    }



    // retorna o nome do estado que no caso é o nome desse script
    public override string GetStateName()
    {
        return this.GetType().ToString();
    }


    public override void TakeDamage(Bruxa bruxa)
    {
        bruxa.SwitchState(bruxa.movementState);
    }
}
