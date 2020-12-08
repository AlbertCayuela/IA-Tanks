using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("MyActions/WanderAction")]

public class WanderAction : BasePrimitiveAction
{
    [InParam("wander_tank")]
    public GameObject wander_tank;

    [OutParam("wander_destination")]
    public Vector3 wander_destination;

    public override TaskStatus OnUpdate()
    {
        WanderTreeScript wander = wander_tank.GetComponent<WanderTreeScript>();

        wander_destination = wander.WanderDestination();

        return TaskStatus.COMPLETED;
    }
}
