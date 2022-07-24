using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ZombieAttackState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager zombie)
    {
        zombie.StartCoroutine(ZombieAttackCoroutine(zombie));
    }
    IEnumerator ZombieAttackCoroutine(ZombieStateManager zombie)
    {
        zombie.zombieAnimator.Play("Attack");
        Debug.Log("Zombie preparando ataque");
        yield return new WaitForSeconds(1.05f);
        Collider[] hitPlayer = Physics.OverlapSphere(zombie.AttackPoint.transform.position,2);
        foreach(var objhitted in hitPlayer)
        {
            if (objhitted.gameObject.CompareTag("Player"))
            {
                Debug.Log("Zombie Atacou o Player");
                objhitted.GetComponent<Bruxa>().TakeDamage();
            }
        }
        yield return new WaitForSeconds(0.8f);

        zombie.SwitchState(zombie._walkState);
    }
    public override void OnCollisionEnter(ZombieStateManager zombie)
    {
    }

    public override void UpdateState(ZombieStateManager zombie)
    {
    }

    public override string GetCurrentState(ZombieStateManager zombie)
    {
        return "Attack State";
    }
}
