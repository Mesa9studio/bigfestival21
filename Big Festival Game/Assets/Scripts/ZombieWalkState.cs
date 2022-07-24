using UnityEngine;

public class ZombieWalkState : ZombieBaseState
{
    [SerializeField]float recoilDamageTime=0.5f;
    [SerializeField]float currentDamageTime = 0;
    [SerializeField]bool doattack = false;
    public override void EnterState(ZombieStateManager zombie)
    {
        currentDamageTime = 0;
        zombie.transform.LookAt(zombie.bruxinha.transform.position);
        zombie._agent.SetDestination(zombie.bruxinha.transform.position);
        zombie._agent.stoppingDistance = 1.5f;
        zombie.zombieAnimator.Play("Walk");

    }

    public override void OnCollisionEnter(ZombieStateManager zombie)
    {
    }

    public override void UpdateState(ZombieStateManager zombie)
    {
        zombie._agent.SetDestination(zombie.bruxinha.transform.position);
        zombie.transform.LookAt(zombie.bruxinha.transform.position);
        if (Vector3.Distance(zombie.gameObject.transform.position, zombie.bruxinha.transform.position) > 12f)
        {
            zombie.SwitchState(zombie._workState);

        }

        if (doattack)
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime >= recoilDamageTime)
            {
                zombie.SwitchState(zombie._attackState);
                doattack = false;
            }
            return;
        }
        if (Vector3.Distance(zombie.transform.position, zombie.bruxinha.transform.position) <= zombie._agent.stoppingDistance)
        {
            doattack = true;
        }
        else
        {
            doattack = false;
        }
    }

    public override string GetCurrentState(ZombieStateManager zombie)
    {
        return "Walk State";
    }
}
