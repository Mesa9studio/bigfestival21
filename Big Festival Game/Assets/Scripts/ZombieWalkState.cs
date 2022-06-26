using UnityEngine;

public class ZombieWalkState : ZombieBaseState
{
    float recoilDamageTime=0.5f;
    float currentDamageTime = 0;
    bool doattack = false;
    public override void EnterState(ZombieStateManager zombie)
    {
        currentDamageTime = 0;
        zombie.transform.LookAt(zombie.bruxinha.transform.position);
        zombie._agent.SetDestination(zombie.bruxinha.transform.position);
        zombie._agent.stoppingDistance = 2;

    }

    public override void OnCollisionEnter(ZombieStateManager zombie)
    {
    }

    public override void UpdateState(ZombieStateManager zombie)
    {
        zombie._agent.SetDestination(zombie.bruxinha.transform.position);
        zombie.transform.LookAt(zombie.bruxinha.transform.position);
        if (Input.GetKeyDown(KeyCode.A))
        {
            zombie.SwitchState(zombie._workState);
        }

        if (doattack)
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime >= recoilDamageTime)
            {
                doattack = false;
            }
            return;
        }
        if (Vector3.Distance(zombie.transform.position, zombie.bruxinha.transform.position) <= zombie._agent.stoppingDistance)
        {
            Debug.Log(zombie.transform.name + "Executar o ataque na bruxinha");
            zombie.SwitchState(zombie._attackState);
            doattack = true;
        }
    }

    public override string GetCurrentState(ZombieStateManager zombie)
    {
        return "Walk State";
    }
}
