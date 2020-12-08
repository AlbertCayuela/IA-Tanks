using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeTreeScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshHit hit;

    public GameObject tank;

    public Vector3 dir_to_tank;
    public Vector3 new_pos;
    public float destination_distance;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        dir_to_tank = transform.position - tank.transform.position;

        new_pos = transform.position + dir_to_tank;

        agent.autoBraking = false;
    }

    public Vector3 FleeDestination()
    {
        destination_distance = Vector3.Distance(transform.position, new_pos);

        Debug.DrawLine(transform.position, new_pos, Color.cyan);

        if (CheckIfWalkable(new_pos) || destination_distance <= 6.5f)
        {
            dir_to_tank = transform.position - tank.transform.position;

            new_pos = transform.position + dir_to_tank;

        }

        return new_pos;
    }

    //function to check if the point where the tank is going is in the walkable zone
    bool CheckIfWalkable(Vector3 new_pos)
    {
        if (NavMesh.Raycast(transform.position, new_pos, out hit, NavMesh.AllAreas))
            return true;
        else return false;
    }
}
