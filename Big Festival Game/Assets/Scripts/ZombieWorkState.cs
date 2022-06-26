using UnityEngine;

public class ZombieWorkState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager zombie)
    {
        zombie.transform.LookAt(zombie.DefaultPositionLook);
        zombie._agent.SetDestination(zombie.DefaultPositionSpawn.position);
        zombie._agent.stoppingDistance = 0;

    }

    public override void OnCollisionEnter(ZombieStateManager zombie)
    {
    }

    public override void UpdateState(ZombieStateManager zombie)
    {
        if (Vector3.Distance(zombie.transform.position, zombie.DefaultPositionSpawn.position) <= zombie._agent.stoppingDistance+1.5f)
        {
            Debug.Log(zombie.transform.name+"Executar animacao ");
        }
        else
        {
            Debug.Log(zombie.transform.name + "Nao Executar animação ainda");
            Debug.Log(zombie.name+" "+Vector3.Distance(zombie.transform.position, zombie.DefaultPositionSpawn.position));

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            zombie.SwitchState(zombie._walkState);
        }
    }

    public override string GetCurrentState(ZombieStateManager zombie)
    {
        return "Work State";
    }
}
