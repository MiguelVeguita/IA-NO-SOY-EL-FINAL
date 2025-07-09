using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LogicDiffuseDog: LogicDiffuse
{
    public FuzzySystem SpeedDependDistanceItem = new FuzzySystem();
    private void Awake()
    {
        this.LoadScriptableObject();
    }

    public override void LoadScriptableObject()
    {
        if (logicDiffuseData != null)
        {
            // Usa los valores preconfigurados en el ScriptableObject
            SpeedDependDistanceEnemy = logicDiffuseData.SpeedDependDistanceEnemy;
            SpeedDependDistanceAllied = logicDiffuseData.SpeedDependDistanceAllied;
            SpeedDependDistancePosition = logicDiffuseData.SpeedDependDistancePosition;
            
            SpeedDependDistanceItem = ((LogicDiffuseDataScriptableObjectWolf)logicDiffuseData).SpeedDependDistanceItem;

        }
    }
}
