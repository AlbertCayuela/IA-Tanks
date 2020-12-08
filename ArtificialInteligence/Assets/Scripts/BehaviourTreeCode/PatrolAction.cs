using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("MyActions/PatrolAction")]

public class PatrolAction : BasePrimitiveAction
{
    [InParam("patrol_tank")]
    public GameObject patrol_tank;

    [OutParam("patrol_destination")]
    public Vector3 patrol_destination;

    public override TaskStatus OnUpdate()
    {
        PatrolTreeScript patrol = patrol_tank.GetComponent<PatrolTreeScript>();

        patrol_destination = patrol.PatrolDestination();

        return TaskStatus.COMPLETED;
    }
}
