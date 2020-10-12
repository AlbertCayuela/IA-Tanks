using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAgent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    private Transform[] points;

    private int destinationPoint = 0;

    private NavMeshAgent agent;
    private float minimunremainingDinstance = 1.5f;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {

        if(!agent.pathPending && agent.remainingDistance < minimunremainingDinstance)
        {
            GoToNextPoint();
        }

    }


    void GoToNextPoint()
    {

        if(points.Length == 0)
        {
            Debug.LogError("Not working well");
            enabled = false;
            return;
        }

        agent.destination = points[destinationPoint].position;

        destinationPoint = (destinationPoint + 1) % points.Length;

    }
}
