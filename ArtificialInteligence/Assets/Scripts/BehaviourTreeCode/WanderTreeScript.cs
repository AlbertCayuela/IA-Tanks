using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WanderTreeScript : MonoBehaviour
{
    public Transform[] wander_points;

    public Vector3 destination;

    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        destination = wander_points[i].position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 WanderDestination()
    {

        if (Vector3.Distance(destination, transform.position) < 1.5f && i == 8)
        {
            Debug.Log("is 8");
            i = 0;
            destination = wander_points[i].position;
        }
        else if (Vector3.Distance(destination, transform.position) < 1.5f)
        {
            i++;
            destination = wander_points[i].position;
        }

        destination = wander_points[i].position;

        return destination;
    }
}