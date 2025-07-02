using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class IACharacterVehiculoWolf : IACharacterCaninus
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
        agent.speed = ((LogicDiffuseWolf)_LogicDiffuse).SpeedDependDistancePosition.CalculateFuzzy(dist);
    }
    public override void MoveToItem()
    {
 
        base.MoveToItem();
        if (AIEye.ViewFood == null) return;
        float dist = (transform.position - AIEye.ViewFood.transform.position).magnitude;
        agent.speed = ((LogicDiffuseWolf)_LogicDiffuse).SpeedDependDistanceItem.CalculateFuzzy(dist);
    }
    private void OnDrawGizmos()
    {
        if (!IsDrawGizmos) return;
        base.DrawGizmos();
    }
}
