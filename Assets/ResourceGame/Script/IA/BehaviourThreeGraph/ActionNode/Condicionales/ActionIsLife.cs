using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/View")]
public class ActionIsLife : ActionNodeView
{
    public override void OnAwake()
    {
        base.OnAwake();

    }
    public override TaskStatus OnUpdate()
    {
       
        if (_IACharacterActions.AIEye.ViewFood.IsDead)
            return TaskStatus.Failure;


        return TaskStatus.Success;
    }

}
