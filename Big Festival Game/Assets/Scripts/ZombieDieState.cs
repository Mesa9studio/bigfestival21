using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ZombieDieState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager zombie)
    {
        zombie.ZombieDie = true;
        Debug.Log("Aux State"+zombie.auxState.GetCurrentState(zombie));
        zombie._agent.SetDestination(zombie._agent.transform.position);
        zombie.StartCoroutine(ZombieDieCoroutine(zombie));
    }
    IEnumerator ZombieDieCoroutine(ZombieStateManager zombie)
    {
        zombie.zombieAnimator.Play("dead");
        yield return new WaitForSeconds(6.7f);
        zombie.ZombieDie = false;
        zombie.SwitchState(zombie.auxState);
        zombie.auxState = null;
    }
    public override void OnCollisionEnter(ZombieStateManager zombie)
    {
    }

    public override void UpdateState(ZombieStateManager zombie)
    {       
    }

    public override string GetCurrentState(ZombieStateManager zombie)
    {
        return "Die State";
    }
}
