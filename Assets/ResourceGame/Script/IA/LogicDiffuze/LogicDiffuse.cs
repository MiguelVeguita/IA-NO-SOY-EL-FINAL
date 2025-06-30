using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FuzzyRule
{
    public string Condition; // Ejemplo: "Si X es BAJO entonces Y es ALTO"
    public float Weight; // Peso de la regla
}

[System.Serializable]
public class FuzzyFunction
{
    public string Name; // Nombre de la función de membresía (Ej: "BAJO", "MEDIO", "ALTO")
    public AnimationCurve FunctionCurve; // Curva de membresía
    public FuzzyRule AssociatedRule; // Regla asociada a la función
    public float SingletonDistance; // Valor asociado a la función en la desfusificación

    public float Evaluate(float x)
    {
        return Mathf.Clamp01(FunctionCurve.Evaluate(x)); // Evalúa el grado de pertenencia
    }

    public float GetMaxValue()
    {
        return FunctionCurve.keys.Length > 0 ? FunctionCurve.keys[FunctionCurve.length - 1].value : 0;
    }
}

public static class FuzzyOperators
{
    public static float FuzzyAND(float a, float b) => Mathf.Min(a, b);
    public static float FuzzyOR(float a, float b) => Mathf.Max(a, b);
    public static float FuzzyNOT(float a) => 1.0f - a;
}

[System.Serializable]
public class FuzzySystem
{
    public List<FuzzyFunction> MembershipFunctions = new List<FuzzyFunction>(); // Lista de funciones de membresía
    public float Promedio;
    public float CalculateFuzzy(float inputValue, float secondaryInput = 1.0f)
    {
        float SumaW = 0;
        float MultW = 0;

        foreach (var fuzzyFunction in MembershipFunctions)
        {
            float membershipValue = fuzzyFunction.Evaluate(inputValue); // Evalúa la entrada en la función de membresía

            if (membershipValue > 0 && fuzzyFunction.AssociatedRule != null)
            {
                float weightedValue = membershipValue * fuzzyFunction.SingletonDistance; // Ponderación
                SumaW += membershipValue; // Suma de los grados de pertenencia
                MultW += weightedValue; // Multiplicación ponderada
            }
        }
        Promedio= (SumaW != 0) ? MultW / SumaW : MultW;
        // Aplicamos desfusificación: Promedio ponderado
        return (SumaW != 0) ? MultW / SumaW : MultW;
    }

    public float MaxValue()
    {
        float maxValue = 0;
        foreach (var function in MembershipFunctions)
        {
            maxValue = Mathf.Max(maxValue, function.GetMaxValue());
        }
        return maxValue;
    }
}

public class LogicDiffuse: MonoBehaviour
{
    public LogicDiffuseDataScriptableObject logicDiffuseData;
    public FuzzySystem SpeedDependDistanceEnemy = new FuzzySystem();
    public FuzzySystem SpeedDependDistanceAllied = new FuzzySystem();
    public FuzzySystem SpeedDependDistancePosition = new FuzzySystem();

     

    public virtual void LoadScriptableObject()
    {
        if (logicDiffuseData != null)
        {
            // Usa los valores preconfigurados en el ScriptableObject
            SpeedDependDistanceEnemy = logicDiffuseData.SpeedDependDistanceEnemy;
            SpeedDependDistanceAllied = logicDiffuseData.SpeedDependDistanceAllied;
            SpeedDependDistancePosition = logicDiffuseData.SpeedDependDistancePosition;
             
        }
    }
}
