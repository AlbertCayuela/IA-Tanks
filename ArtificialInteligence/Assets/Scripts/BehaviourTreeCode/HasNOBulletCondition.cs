using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/HasNOBullets")]

public class HasNOBulletCondition : ConditionBase
{

    [InParam("this_tank")]
    public GameObject this_tank;

    public override bool Check()
    {
        Shoot shoot = this_tank.GetComponent<Shoot>();

        return shoot.HasNOBullets();
    }
}
