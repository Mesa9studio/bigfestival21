using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }
}
