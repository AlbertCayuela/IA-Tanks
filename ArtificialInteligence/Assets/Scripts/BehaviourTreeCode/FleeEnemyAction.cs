using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("MyActions/FleeEnemy")]

public class FleeEnemyAction : BasePrimitiveAction
{
    [InParam("wandering_tank")]
    public GameObject wandering_tank;

    [OutParam("flee_destination")]
    public Vector3 flee_destination;

    public override TaskStatus OnUpdate()
    {
        FleeTreeScript flee = wandering_tank.GetComponent<FleeTreeScript>();

        flee_destination = flee.FleeDestination();

        return TaskStatus.COMPLETED;
    }
}


