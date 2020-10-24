using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Flee : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject target;

    //public float enemy_distance_run = 50;

    //public float distance;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { 
        //distance = Vector3.Distance(transform.position, target.transform.position);

        //Debug.Log("Distance:  +" + distance);

        //Run away from tanks
        Vector3 dir_to_tank = transform.position - target.transform.position;

        Vector3 new_pos = transform.position + dir_to_tank;

        agent.SetDestination(new_pos);
    }

   
}
