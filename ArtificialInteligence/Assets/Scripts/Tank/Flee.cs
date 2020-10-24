using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject target;

    public float time_stuck; //variable created to make sure the tank is not stuck
    public bool stuck = false;
    //public float enemy_distance_run = 50;
    //vector3 target points

    private NavMeshHit hit;

    public float radius = 2f; //radius of the zone the next point will be created

    //min and max offset where 
    public float min_offset = 10f;
    public float max_offset = 20f;


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

       

        time_stuck += Time.deltaTime;



        if (CheckIfWalkable2(dir_to_tank) || CheckIfWalkable(new_pos)|| TargetNotAchievable())
        {
            if (stuck)
            {
                min_offset = -min_offset;
                max_offset = -max_offset;
                //stuck = false;
            }
    
            if (stuck)
            {
                min_offset = -min_offset;
                max_offset = -max_offset;
                stuck = false;
            }

            time_stuck = 0;
            agent.SetDestination(new_pos);
        }
    }
        bool CheckIfWalkable(Vector3 new_pos)
        {
            if (NavMesh.Raycast(transform.position, new_pos, out hit, NavMesh.AllAreas))
                return true;
            else return false;
        }
         bool CheckIfWalkable2(Vector3 dir_to_tank)
        {
             if (NavMesh.Raycast(transform.position, dir_to_tank, out hit, NavMesh.AllAreas))
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
