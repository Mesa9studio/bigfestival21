using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDieState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager zombie)
    {
        zombie.ZombieDie = true;
        zombie._agent.SetDestination(zombie._agent.transform.position);
        zombie.StartCoroutine(ZombieDieCoroutine(zombie));
    }
    IEnumerator ZombieDieCoroutine(ZombieStateManager zombie)
    {
        yield return new WaitForSeconds(3f);
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
