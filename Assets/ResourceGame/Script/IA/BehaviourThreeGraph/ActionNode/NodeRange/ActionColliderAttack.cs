using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Range")]
public class ActionColliderAttack : ActionNodeRange
{
    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

         return SwitchUnit();
        
    }
    TaskStatus SwitchUnit()
    {


        switch (_UnitGame)
        {
            case UnitGame.Wolf:
                if (_IACharacterVehiculo.AIEye is IAEyeNPCAttackWolf IAEyeWolf)
                {
                    
                    if (IAEyeWolf != null && IAEyeWolf.AttackDataViewItem.Sight)
                        return TaskStatus.Success;
                }

                break;
            case UnitGame.Dog:
                if (_IACharacterVehiculo.AIEye is IAEyeNPCAttackDog IAEyeDog)
                {

                    if (IAEyeDog != null && IAEyeDog.AttackDataViewEnemy.Sight)
                        return TaskStatus.Success;
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }

        return TaskStatus.Failure;

    }


}