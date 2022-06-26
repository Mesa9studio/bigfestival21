using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruxa2 : MonoBehaviour
{
    public Rigidbody myRb;
    public int flyMaxLevel=2;
    public float flyLevelDistance=1, delayToChangeFlyLevel=2;
    int currentFlyingLevel=0;
    bool switchingFlyLevel = false;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));

        if(movement.magnitude != 0)
            movement /= movement.magnitude; // mantem a velocididade na diagonal igual na vertical e horizontal

        myRb.MovePosition(transform.position + movement * Time.deltaTime * movementSpeed);
    }

    void Fly()
    {
        if(switchingFlyLevel) return;

        if (Input.GetKeyDown("e"))
        {
            if(currentFlyingLevel >= flyMaxLevel) return;
            StartCoroutine(SwitchFly());

        }
        else if (Input.GetKeyDown("q"))
        {
            if(currentFlyingLevel <= 0) return;
            StartCoroutine(SwitchFly(-1));
        }
    }


    IEnumerator SwitchFly(int dir=1) // dir = 1 -> up  |  dir = -1 -> down
    {
        switchingFlyLevel = true;

        if(currentFlyingLevel == 0)
            myRb.isKinematic = true;

        float aux = 0, end_y = transform.position.y + flyLevelDistance * dir;

        while(aux <= delayToChangeFlyLevel)
        {
            transform.position += Vector3.up*Time.deltaTime*flyLevelDistance/delayToChangeFlyLevel*dir;
            aux += Time.deltaTime;
            yield return null;
        }

        currentFlyingLevel += dir;
        transform.position = new Vector3(transform.position.x,end_y,transform.position.z);

        if(currentFlyingLevel == 0)
            myRb.isKinematic = false;

        switchingFlyLevel = false;
    }
}
