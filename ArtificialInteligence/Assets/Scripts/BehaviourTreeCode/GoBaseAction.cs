using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("MyActions/GoBase")]

public class GoBaseAction : BasePrimitiveAction
{
    [InParam("base_")]
    public Transform base_;

    [OutParam("base_position")]
    public Vector3 base_position;

    public override TaskStatus OnUpdate()
    {
        base_position = base_.position;

        return TaskStatus.COMPLETED;
    }
}
