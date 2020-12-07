using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/IsEnemyFar")]

public class EnemyFarCondition : ConditionBase
{
    public override bool Check()
    {
        GameObject patrolling_tank = GameObject.Find("PatrolTank");
        GameObject wandering_tank = GameObject.Find("WanderTank");
        return Vector3.Distance(patrolling_tank.transform.position, wandering_tank.transform.position) > 20f;
    }
}
