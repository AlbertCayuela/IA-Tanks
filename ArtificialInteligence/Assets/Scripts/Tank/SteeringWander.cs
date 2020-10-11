using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SteeringWander : MonoBehaviour
{

    public float radius = 2f;
    public float offset = 3f;
    public Vector3 local_target;
    public Vector3 world_target;
    public NavMeshAgent agent;
    public float distance_to_target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //calculate first wandering point
        local_target = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        local_target.Normalize();
        local_target *= radius;
        local_target += new Vector3(0, 0, offset);

        world_target = transform.TransformPoint(local_target);
        world_target.y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate distance to the next point the tank is going
        distance_to_target = Vector3.Distance(world_target, transform.position);
        //draw a debug line to check where is the point while doing the game
        Debug.DrawLine(transform.position, world_target, Color.red);

        //reduce amount of points calculated --> if distance is less than x, calculate new point
        if (distance_to_target <= 3)
        {

            local_target = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            local_target.Normalize();
            local_target *= radius;
            local_target += new Vector3(0, 0, offset);

            world_target = transform.TransformPoint(local_target);
            world_target.y = 0f;
        }

        //set tank target as agent destination
        agent.destination = world_target;
    }
 
}
