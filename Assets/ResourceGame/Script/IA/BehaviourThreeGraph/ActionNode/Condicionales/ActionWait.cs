using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
[TaskCategory("MyAI/BaseClass")]
[TaskDescription("Wait a specified amount of time. The task will return running until the task is done waiting. It will return success after the wait time has elapsed.")]
[TaskIcon("{SkinColor}WaitIcon.png")]
public class ActionWait : ActionNodeAction
{
     
    public float waitTime = 1;
     
    public bool randomWait = false;
     
    public float randomWaitMin = 1;
     
    public float randomWaitMax = 1;

    // The time to wait
    private float waitDuration;
    // The time that the task started to wait.
    private float startTime;
    // Remember the time that the task is paused so the time paused doesn't contribute to the wait time.
    private float pauseTime;
    public override void OnAwake()
    {
        base.OnAwake();
        startTime = Time.time;
        if (randomWait)
        {
            waitDuration = Random.Range(randomWaitMin, randomWaitMax);
        }
        else
        {
            waitDuration = waitTime;
        }
    }

    public override TaskStatus OnUpdate()
    {

        if (_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        if (_IACharacterActions.AIEye.ViewEnemy != null)
            return TaskStatus.Failure;

        if (_IACharacterActions.AIEye.ViewFood != null)
            return TaskStatus.Failure;

        SwitchUnit();

        if (startTime + waitDuration < Time.time)
        {
            return TaskStatus.Success;
        }
        // Otherwise we are still waiting.
        return TaskStatus.Running;
    }
    void SwitchUnit()
    {
        switch (_UnitGame)
        {
            case UnitGame.Wolf:
                //if (_IACharacterActions is IACharacterActionsWolf)
                //{
                //    ((IACharacterActionsWolf)_IACharacterActions).Attack();
                //}

                break;
            case UnitGame.Item:
                //if (_IACharacterActions is IACharacterActionsSoldier)
                //{
                //    ((IACharacterActionsSoldier)_IACharacterActions).Attack();
                //}

                break;
            case UnitGame.None:
                break;
            default:
                break;
        }


    }
}
