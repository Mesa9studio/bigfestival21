using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager zombie)
    {
        zombie.StartCoroutine(ZombieDieCoroutine(zombie));
    }
    IEnumerator ZombieDieCoroutine(ZombieStateManager zombie)
    {
        zombie.zombieAnimator.Play("Attack");
        Debug.Log("Zombie preparando ataque");
        yield return new WaitForSeconds(1f);
        Collider[] hitPlayer = Physics.OverlapSphere(zombie.AttackPoint.transform.position,5);

        foreach(var objhitted in hitPlayer)
        {
            if (objhitted.gameObject.CompareTag("Player"))
            {
                Debug.Log("Zombie Atacou o Player");
                objhitted.GetComponent<Bruxa>().TakeDamage();
            }
        }
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
