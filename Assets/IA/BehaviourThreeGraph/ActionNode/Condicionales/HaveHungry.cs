using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class HaveHungry : ActionNodeAction
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {

        if (_IACharacterVehiculo.hunger.IsStarving)
            return TaskStatus.Success;

        SwitchUnit();

        return TaskStatus.Failure;
    }
    void SwitchUnit()
    {

    }

}
