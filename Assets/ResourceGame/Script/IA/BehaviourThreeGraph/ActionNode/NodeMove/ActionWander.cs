using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Move")]
public class ActionWander : ActionNodeVehicle
{
    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        SwitchUnit();

        return TaskStatus.Success;

    }
    void SwitchUnit()
    {

        switch (_UnitGame)
        {
            case UnitGame.Wolf:
                if (_IACharacterVehiculo is IACharacterVehiculoWolf)
                {
                    ((IACharacterVehiculoWolf)_IACharacterVehiculo).MoveToWander();

                }

                break;
            case UnitGame.Item:
                if (_IACharacterVehiculo is IACharacterVehiculoGallina)
                {
                    ((IACharacterVehiculoGallina)_IACharacterVehiculo).MoveToWander();

                }
                break;
            case UnitGame.Dog:
                if (_IACharacterVehiculo is IACharacterVehiculoDog)
                {
                    ((IACharacterVehiculoDog)_IACharacterVehiculo).MoveToWander();

                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }



    }

}