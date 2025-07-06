using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Action")]


public class ActionEatFood : ActionNodeAction
{

    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        SwitchUnit();

        return TaskStatus.Success;

    }
    void SwitchUnit()
    {


        switch (_UnitGame)
        {
            case UnitGame.Wolf:
                if (_IACharacterActions is IACharacterActionsWolf)
                {
                    ((IACharacterActionsWolf)_IACharacterActions).DamageEating();
                    ((IACharacterActionsWolf)_IACharacterActions).Eating();
                   
                }

                break;
            case UnitGame.Item:
                if (_IACharacterActions is IACharacterActionsSoldier)
                {
                    ((IACharacterActionsSoldier)_IACharacterActions).DamageEating();
                }

                break;
            case UnitGame.None:
                break;
            default:
                break;
        }



    }
}