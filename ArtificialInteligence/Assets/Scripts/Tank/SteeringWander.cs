using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SteeringWander : MonoBehaviour
{

    public float radius = 2f; //radius of the zone the next point will be created

    //min and max offset where 
    public float min_offset = 10f;
    public float max_offset = 20f;

    public float distance_to_change = 6.5f; //distance where tank changes target point

    //vector3 target points
    Vector3 local_target;
    Vector3 world_target;
    
    private NavMeshAgent agent;
    private NavMeshHit hit;

    public float distance_to_target; //distance between tank and target point

    public float time_stuck; //variable created to make sure the tank is not stuck
    public bool stuck = false;

    // Start is called before the first frame update
    void Start()
    {



        agent = GetComponent<NavMeshAgent>();

        //calculate first wandering point
        local_target = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        local_target.Normalize();
        local_target *= radius;
        local_target += new Vector3(0, 0, Random.Range(min_offset, max_offset));

        world_target = transform.TransformPoint(local_target);
        world_target.y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time_stuck += Time.deltaTime;

        //calculate distance to the next point the tank is going
        distance_to_target = Vector3.Distance(world_target, transform.position);
        //draw a debug line to check where is the point while doing the game
        Debug.DrawLine(transform.position, world_target, Color.green);

        //reduce amount of points calculated --> if distance is less than x or the actual point is not walkable, calculate new point
        if (distance_to_target <= distance_to_change || CheckIfWalkable(world_target) || TargetNotAchievable())
        {
            local_target = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            local_target.Normalize();
            local_target *= radius;
            local_target += new Vector3(0, 0, Random.Range(min_offset, max_offset));

            world_target = transform.TransformPoint(local_target);
            world_target.y = 0f;

            if (stuck)
            {
                min_offset = -min_offset;
                max_offset = -max_offset;
                stuck = false;
            }

            time_stuck = 0;
        }

        //set tank target as agent destination
        agent.destination = world_target;
    }

    //function to check if the point where the tank is going is in the walkable zone
    bool CheckIfWalkable(Vector3 wolrd_target)
    {
        if (NavMesh.Raycast(transform.position, world_target, out hit, NavMesh.AllAreas))
            return true;
        else return false;
    }

    bool TargetNotAchievable()
    {
        if (time_stuck >= 10)
            stuck = true;

        return stuck;
    }
 
}
