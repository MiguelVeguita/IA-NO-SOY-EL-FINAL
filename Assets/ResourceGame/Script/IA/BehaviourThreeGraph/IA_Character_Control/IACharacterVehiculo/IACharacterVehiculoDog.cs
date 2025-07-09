using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class IACharacterVehiculoDog : IACharacterCaninus
{


    // Start is called before the first frame update
    private void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
         
    }
    public override void MoveToWander()
    {
        base.MoveToWander();
        float dist = (transform.position - positionWander).magnitude;
        agent.speed = ((LogicDiffuseDog)_LogicDiffuse).SpeedDependDistancePosition.CalculateFuzzy(dist);
    }
    public override void MoveToEnemy()
    {
 
        base.MoveToEnemy();
        if (AIEye.ViewEnemy == null) return;
        float dist = (transform.position - AIEye.ViewEnemy.transform.position).magnitude;
        agent.speed = ((LogicDiffuseDog)_LogicDiffuse).SpeedDependDistanceItem.CalculateFuzzy(dist);
    }
    private void OnDrawGizmos()
    {
        if (!IsDrawGizmos) return;
        base.DrawGizmos();
    }
}
