using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ZombiePauseState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager zombie)
    {
        zombie._agent.SetDestination(zombie.transform.position);
    }
    public override void OnCollisionEnter(ZombieStateManager zombie)
    {
    }

    public override void UpdateState(ZombieStateManager zombie)
    {
    }

    public override string GetCurrentState(ZombieStateManager zombie)
    {
        return "Pause State";
    }
}
