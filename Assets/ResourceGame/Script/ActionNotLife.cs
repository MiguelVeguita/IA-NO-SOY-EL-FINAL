using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/View")]
public class ActionNotLife : ActionNodeView
{
    public override void OnAwake()
    {
        base.OnAwake();

    }
    public override TaskStatus OnUpdate()
    {
       
        if (_IACharacterActions.AIEye.ViewFood.IsDead)
            return TaskStatus.Success;


        return TaskStatus.Failure;
    }

}
