 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LogicDiffuseDataScriptableObject", menuName = "FuzzyLogic/LogicDiffuseDataScriptableObject")]
public class LogicDiffuseDataScriptableObject : ScriptableObject
{
    public FuzzySystem SpeedDependDistanceEnemy = new FuzzySystem();
    public FuzzySystem SpeedDependDistanceAllied = new FuzzySystem();
    public FuzzySystem SpeedDependDistancePosition = new FuzzySystem();
    
}

