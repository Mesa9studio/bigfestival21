using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ZombieAttackState : ZombieBaseState
{
    [SerializeField] AudioClipSystem audioCLip;
    public override void EnterState(ZombieStateManager zombie)
    {
        zombie.StartCoroutine(ZombieAttackCoroutine(zombie));
    }
    IEnumerator ZombieAttackCoroutine(ZombieStateManager zombie)
    {
        zombie.zombieAnimator.Play("Attack");
        Debug.Log("Zombie preparando ataque");
        float timePrepareAttack = 0;
        while(timePrepareAttack < 1.05f)
        {
            if (!GameManager._instance.PauseActive) 
            {
                yield return new WaitForSeconds(0.1f);
                timePrepareAttack += 0.1f;
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
        Collider[] hitPlayer = Physics.OverlapSphere(zombie.AttackPoint.transform.position,2);
        foreach(var objhitted in hitPlayer)
        {
            if (objhitted.gameObject.CompareTag("Player"))
            {
                Debug.Log("Zombie Atacou o Player");
                zombie.PlayAudio(audioCLip.audioClip);
                objhitted.GetComponent<Bruxa>().TakeDamage();
            }
        }

        float timeAfterAttack = 0;
        while (timeAfterAttack < 0.8f)
        {
            if (!GameManager._instance.PauseActive)
            {
                yield return new WaitForSeconds(0.1f);
                timeAfterAttack += 0.1f;
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
        Debug.Log("Zumbie vem ca");
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
