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
        Debug.Log("Zombie preparando ataque");
        yield return new WaitForSeconds(1.2f);
        Debug.Log("Zombie Atacou");
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
