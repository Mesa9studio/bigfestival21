using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
[Serializable]
public class BruxaDeadState : BruxaBaseState
{
    // Start
    public override void EnterState(Bruxa bruxa)
    {
        Debug.Log($"Entrando no estado -> {GetStateName()}");
        bruxa.bruxaAnimator.Play("dead");
        bruxa.StartCoroutine(ChangeGameOverScene());
    }

    IEnumerator ChangeGameOverScene()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Game DeadScene");
    }

    // Update
    public override void UpdateState(Bruxa bruxa)
    {
        // Debug.Log(GetStateName());
    }


    // FixedUpdate
    public override void FixedUpdateState(Bruxa bruxa)
    {
        // Debug.Log(GetStateName());
    }


    // verifica quando o colisor entrou
    public override void OnCollisionEnter(Bruxa bruxa, Collision collision)
    {
        Debug.Log($"O colisor de {GetStateName()} entrou");
    }


    // verifica quando o colisor saiu
    public override void OnCollisionExit(Bruxa bruxa, Collision collision)
    {
        Debug.Log($"O colisor de {GetStateName()} saiu");
    }


    // retorna o nome do estado que no caso é o nome desse script
    public override string GetStateName()
    {
        return this.GetType().ToString();
    }


    public override void TakeDamage(Bruxa bruxa)
    {
        Debug.Log("Não posso mais tomar dano, eu morri :(");
    }
}
