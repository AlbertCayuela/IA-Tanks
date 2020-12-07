using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTreeScript : MonoBehaviour
{

    public Transform[] patrolling_points;

    public Vector3 destination;

    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        destination = patrolling_points[i].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 PatrolDestination()
    {

        if (Vector3.Distance(destination, transform.position) < 1.5f && i == 8)
        {
            Debug.Log("is 8");
            i = 0;
            destination = patrolling_points[i].position;
        }
        else if (Vector3.Distance(destination, transform.position) < 1.5f)
        {
            i++;
            destination = patrolling_points[i].position;
        }

        destination = patrolling_points[i].position;

        return destination;
    }
}
