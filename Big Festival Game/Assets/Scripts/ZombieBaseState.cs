using UnityEngine;

public abstract class ZombieBaseState
{
    public abstract void EnterState(ZombieStateManager zombieState);
    public abstract void UpdateState(ZombieStateManager zombieState);

    public abstract void OnCollisionEnter(ZombieStateManager zombieState);

    public abstract string GetCurrentState(ZombieStateManager zombieState);
}
