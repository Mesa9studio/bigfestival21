using System;
using UnityEngine;
using System.Collections;

public enum MouseButton{Left=0, Right=1}

[Serializable]
public class BruxaFlyState : BruxaBaseState
{

    public float flySpeed,
                 flyLevelDistance=1,
                 delayToChangeFlyLevel=2,
                 flyFuel=10;

    public bool infiniteFuel;

    public int   flyMaxLevel=2;

    public bool flying=false;

    public MouseButton flyMouseButton;

    int currentFlyingLevel=0;
    float currentY;
    bool switchingFlyLevel = false;

    public LayerMask building;

    private Bruxa bx;

    // Start
    public override void EnterState(Bruxa bruxa)
    {
        Debug.Log($"Entrando no estado -> {GetStateName()}");
        bx = bruxa;
        bruxa.myRb.useGravity = false;
        flying = true;
        bruxa.bruxaAnimator.Play("fly");
        currentY = bruxa.transform.position.y;
        // bruxa.StartCoroutine(SwitchFlyLevel(bruxa));
    }


    // Update
    public override void UpdateState(Bruxa bruxa)
    {
        // Debug.Log("AQUI: "+flying);

        // ChangeFlyingLevel(bruxa);
        UpdateFuel();
    }


    // FixedUpdate
    public override void FixedUpdateState(Bruxa bruxa)
    {
        MovementWhileFly(bruxa);
        TryingLandOnTheBuilding();
    }


    // verifica quando o colisor entrou
    public override void OnCollisionEnter(Bruxa bruxa, Collision collision)
    {
        Debug.Log($"O colisor de {GetStateName()} entrou");
        if(collision.gameObject.tag == "Inimigo")
            bruxa.TakeDamage();
    }


    // verifica quando o colisor saiu
    public override void OnCollisionExit(Bruxa bruxa, Collision collision)
    {
        Debug.Log($"O colisor de {GetStateName()} saiu");
    }


    public override void OnTriggerEnter(Bruxa bruxa, Collider collider)
    {
        
    }


    public override void OnTriggerExit(Bruxa bruxa, Collider collider)
    {

    }


    // retorna o nome do estado que no caso é o nome desse script
    public override string GetStateName()
    {
        return this.GetType().ToString();
    }


    public override void TakeDamage(Bruxa bruxa)
    {
        //TODO
    }


    void MovementWhileFly(Bruxa bruxa)
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), GetPropulsion(), Input.GetAxis("Vertical"));

        if(movement.magnitude != 0)
            movement /= movement.magnitude; // mantem a velocidade na diagonal igual na vertical e horizontal

        // bruxa.myRb.MovePosition(Time.deltaTime * flySpeed * movement + bruxa.transform.position);
        // bruxa.transform.position += movement * Time.deltaTime * flySpeed;
        bx.myRb.velocity = Time.deltaTime * flySpeed * movement;
        bruxa.transform.rotation = Quaternion.LookRotation(movement);

        
        // bruxa.transform.position = new Vector3(bruxa.transform.position.x, currentY, bruxa.transform.position.z);
    }

    void TryingLandOnTheBuilding()
    {
        RaycastHit hit;
        if(Physics.Raycast(bx.transform.position, -Vector3.up, out hit, 2f, building))
        {
            if(GetPropulsion() >= 0)
                return;

            bx.SwitchState(bx.movementState);
            // Debug.DrawRay(bx.transform.position, hit.distance*-Vector3.up, Color.red);
        }
    }

    float GetPropulsion()
    {   if(flyFuel > 0)
            return Input.GetAxis("Fly");
        
        return -1;
    }

    void UpdateFuel()
    {
        if(!flying || infiniteFuel) return;

        flyFuel -= Time.deltaTime;
    }

    void ChangeFlyingLevel(Bruxa bruxa)
    {
        if(switchingFlyLevel) return;

        if (Input.GetMouseButton((int)(flyMouseButton)) && flyFuel > 0)
        {
            flying = true;
            Debug.Log("AAAAAAAAA");
            if(currentFlyingLevel >= flyMaxLevel) return;
            bruxa.StartCoroutine(SwitchFlyLevel(bruxa));
        }
        else
        {
            flying = false;
            if(currentFlyingLevel <= 0) return;
            bruxa.StartCoroutine(SwitchFlyLevel(bruxa, -1));
        }

        // if (Input.GetKey(flyUp))
        // {
        //     if(currentFlyingLevel >= flyMaxLevel) return;
        //     bruxa.StartCoroutine(SwitchFlyLevel(bruxa));
        //
        // }
        // else if (Input.GetKey(flyDown))
        // {
        //     if(currentFlyingLevel <= 0) return;
        //     bruxa.StartCoroutine(SwitchFlyLevel(bruxa, -1));
        // }
    }


    IEnumerator SwitchFlyLevel(Bruxa bruxa, int dir=1) // dir = 1 -> up  |  dir = -1 -> down
    {
        switchingFlyLevel = true;

        if(currentFlyingLevel == 0)
            bruxa.myRb.isKinematic = true;

        float aux = 0, end_y = bruxa.transform.position.y + flyLevelDistance * dir;

        while(aux <= delayToChangeFlyLevel)
        {
            bruxa.transform.position += Vector3.up*Time.deltaTime*flyLevelDistance/delayToChangeFlyLevel*dir;
            // currentY += Time.deltaTime*flyLevelDistance/delayToChangeFlyLevel*dir;
            aux += Time.deltaTime;
            yield return null;
        }

        currentFlyingLevel += dir;
        // currentY = end_y;
        bruxa.transform.position = new Vector3(bruxa.transform.position.x,end_y,bruxa.transform.position.z);

        if(currentFlyingLevel == 0)
        {
            bruxa.myRb.isKinematic = false;
            bruxa.SwitchState(bruxa.movementState);
        }

        switchingFlyLevel = false;
    }


}
