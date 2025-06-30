using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/View")]
public class ActionNodeViewItem : ActionNodeView
{
    public override void OnAwake()
    {
        base.OnAwake();

    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterActions.health.IsDead)
            return TaskStatus.Failure;

        if (_IACharacterActions.AIEye.ViewFood == null)
            return TaskStatus.Failure;

        // 4) Si es distinto, fallo
        return TaskStatus.Success;
    }

}