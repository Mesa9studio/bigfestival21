using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float followTargetSpeed;
    public Vector3 targetOffset;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine("FollowTarget");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position+targetOffset, followTargetSpeed);
        // transform.LookAt(target);
    }

    IEnumerator FollowTarget()
    {
        while(true)
        {
            //TODO
            transform.position = Vector3.MoveTowards(transform.position, target.position+targetOffset, followTargetSpeed);
            transform.LookAt(target);
            yield return null;
        }
    }
}
