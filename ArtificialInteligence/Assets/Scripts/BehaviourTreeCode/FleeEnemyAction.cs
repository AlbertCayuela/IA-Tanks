using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("MyActions/FleeEnemy")]

public class FleeEnemyAction : BasePrimitiveAction
{
    [InParam("enemy_tank")]
    public GameObject enemy_tank;

    [OutParam("enemy_position")]
    public Vector3 enemy_position;

    public override TaskStatus OnUpdate()
    {
        enemy_position = enemy_tank.transform.position;

        return TaskStatus.COMPLETED;
    }
}


