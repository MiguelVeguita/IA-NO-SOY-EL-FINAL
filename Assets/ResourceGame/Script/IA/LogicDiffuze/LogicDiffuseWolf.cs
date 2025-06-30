using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LogicDiffuseWolf: LogicDiffuse
{
    public FuzzySystem EvadeDependDistanceEnemy = new FuzzySystem();
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

            EvadeDependDistanceEnemy = ((LogicDiffuseDataScriptableObjectWolf)logicDiffuseData).EvadeDependDistanceEnemy;
            SpeedDependDistanceItem = ((LogicDiffuseDataScriptableObjectWolf)logicDiffuseData).SpeedDependDistanceItem;
        }
    }
}
