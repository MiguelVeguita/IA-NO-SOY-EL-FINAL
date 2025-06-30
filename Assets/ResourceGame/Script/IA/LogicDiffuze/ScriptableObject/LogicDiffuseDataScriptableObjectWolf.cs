 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LogicDiffuseDataScriptableObject", menuName = "FuzzyLogic/LogicDiffuseDataScriptableObjectWolf")]
public class LogicDiffuseDataScriptableObjectWolf : LogicDiffuseDataScriptableObject
{
    public FuzzySystem EvadeDependDistanceEnemy = new FuzzySystem();
    public FuzzySystem SpeedDependDistanceItem = new FuzzySystem();

}

