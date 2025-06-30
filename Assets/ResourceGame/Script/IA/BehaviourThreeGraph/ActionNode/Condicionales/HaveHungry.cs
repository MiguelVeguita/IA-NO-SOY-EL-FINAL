using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class HaveHungry : ActionNodeAction
{
    public override void OnAwake()
    {
        base.OnAwake();
    }

    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;
         
        if (_IACharacterVehiculo.hunger.IsStarving)
            return TaskStatus.Success;
        return TaskStatus.Failure;
    }
     
}
