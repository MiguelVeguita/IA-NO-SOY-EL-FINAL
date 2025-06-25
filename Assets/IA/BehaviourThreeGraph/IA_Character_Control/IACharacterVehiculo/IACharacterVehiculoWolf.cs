using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class SpeedFuzzyLogicProfile
{
    [Tooltip("Función difusa para 'distancia cercana' a la gallina.")]
    public FuzzyFunction cercaGallinaFunction = new FuzzyFunction(); // Renombrado para claridad
    [Tooltip("Función difusa para 'distancia media' a la gallina.")]
    public FuzzyFunction mediaGallinaFunction = new FuzzyFunction(); // Renombrado para claridad
    [Tooltip("Función difusa para 'distancia lejana' a la gallina.")]
    public FuzzyFunction lejosGallinaFunction = new FuzzyFunction();   // Renombrado para claridad
}
public class IACharacterVehiculoWolf : IACharacterVehiculo
{
    public Animator animator;

    [Header("Lógica Difusa de Velocidad del Lobo")]
    [Tooltip("Perfil con las funciones difusas (cerca, medio, lejos) para ajustar la velocidad al seguir a la gallina.")]
    public SpeedFuzzyLogicProfile fuzzySpeedProfile = new SpeedFuzzyLogicProfile();

    [Tooltip("Velocidad mínima que el lobo puede alcanzar al usar lógica difusa.")]
    public float minSpeedFuzzy = 3.0f;

    [Tooltip("Velocidad máxima que el lobo puede alcanzar al usar lógica difusa.")]
    public float maxSpeedFuzzy = 12.0f;

    [Tooltip("Velocidad por defecto del lobo cuando no está aplicando lógica difusa (ej. patrullando).")]
    public float defaultPatrolSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        if (agent != null)
        {
            // Al inicio, el lobo podría tener su velocidad de patrulla por defecto
            agent.speed = defaultPatrolSpeed;
        }
    }
    
    public override void MoveToPosition(Vector3 pos)
    {
        base.MoveToPosition(pos);

    }

    public override void MoveToEnemy()
    {
        if (AIEye == null || AIEye.ViewEnemy == null || AIEye.ViewEnemy.IsDead)
        {
            if (agent != null)
            {           
                agent.speed = defaultPatrolSpeed;
            }
            return;
        }
        if (agent != null)
        {
            float distanceToGallina = Vector3.Distance(transform.position, AIEye.ViewEnemy.transform.position);

            float fCerca = fuzzySpeedProfile.cercaGallinaFunction.Evaluate(distanceToGallina);
            float fMedia = fuzzySpeedProfile.mediaGallinaFunction.Evaluate(distanceToGallina);
            float fLejos = fuzzySpeedProfile.lejosGallinaFunction.Evaluate(distanceToGallina);

            float numerator = (fCerca * fuzzySpeedProfile.cercaGallinaFunction.Singleton) +
                              (fMedia * fuzzySpeedProfile.mediaGallinaFunction.Singleton) +
                              (fLejos * fuzzySpeedProfile.lejosGallinaFunction.Singleton);

            float denominator = fCerca + fMedia + fLejos;

            float calculatedSpeed;
            if (Mathf.Approximately(denominator, 0))
            {
                calculatedSpeed = defaultPatrolSpeed; // O agent.speed para mantener la actual
            }
            else
            {
                calculatedSpeed = numerator / denominator;
            }

            agent.speed = Mathf.Clamp(calculatedSpeed, minSpeedFuzzy, maxSpeedFuzzy);

            agent.SetDestination(AIEye.ViewEnemy.transform.position);
        }

    }
    public override void MoveToAllied()
    {
        base.MoveToAllied( );
    }
    public override void MoveToEvadEnemy()
    {
        base.MoveToEvadEnemy( );
    }

}
