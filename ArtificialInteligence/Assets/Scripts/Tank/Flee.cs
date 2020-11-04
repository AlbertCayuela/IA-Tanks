﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : MonoBehaviour
{

    private NavMeshAgent agent;

    public GameObject tank;

    public float EnemyDistanceRun = 5.0f;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToTank = transform.position - tank.transform.position;

        Vector3 newPos = transform.position + dirToTank;

        Debug.DrawLine(transform.position, newPos, Color.cyan);

        agent.SetDestination(newPos);
    }
}
