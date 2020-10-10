using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringUpdate : MonoBehaviour
{
    public GameObject target;
    public float stopDistance;
    public float turnSpeed;
    public float turnAcceleration;
    public float maxTurnSpeed;
    public float movSpeed;
    public float acceleration;
    public float maxSpeed;
    public Quaternion rotation;

    SteeringSeek seek;

    // Start is called before the first frame update
    void Start()
    {
        seek = GetComponent<SteeringSeek>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < stopDistance) return;
        seek.Seek();   // calls to this function should be reduced
        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);
        transform.rotation = Quaternion.Slerp(seek.rotation, transform.rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;
    }
}
