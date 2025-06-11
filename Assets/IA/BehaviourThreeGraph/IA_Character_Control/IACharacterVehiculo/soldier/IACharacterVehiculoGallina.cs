using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoGallina : IACharacterVehiculo
{
    private Animator animator;
    public string verticalAnimatorID = "Vert";
    public float patrolSpeed = 1.5f;
    Vector3 normales = Vector3.zero;
    public bool ISDrawGizmos = false;
    // Start is called before the first frame update
    void Start()
    {
        ISDrawGizmos=true;
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("¡No se encontró el componente Animator en la gallina! Es necesario para las animaciones.");
        }

        // Asignamos la velocidad de patrulla al NavMeshAgent
        if (agent != null)
        {
            agent.speed = patrolSpeed;
        }
    }
    void Update()
    {
        // Si no tenemos animator o agent, no hacemos nada
        if (animator == null || agent == null)
        {
            return;
        }

        // Calculamos la velocidad actual del NavMeshAgent como un porcentaje de su velocidad máxima.
        // agent.velocity.magnitude nos dice qué tan rápido se está moviendo AHORA MISMO.
        // Dividimos por agent.speed para obtener un valor entre 0 (parado) y 1 (velocidad máxima).
        float speedPercent = agent.velocity.magnitude / agent.speed;

        // Actualizamos el parámetro "Vert" en el Animator.
        // El animator usará este valor para decidir si debe pasar de Idle a Walk/Run.
        // El valor 0.1f es un "damp time" para suavizar la transición y que no sea instantánea.
        animator.SetFloat(verticalAnimatorID, speedPercent, 0.1f, Time.deltaTime);
    }
    public override void MoveToWander()
    {
        // Al deambular, nos aseguramos de que tenga la velocidad de patrulla correcta.
        if (agent != null && agent.speed != patrolSpeed)
        {
            agent.speed = patrolSpeed;
        }
        base.MoveToWander(); // Llama a la lógica de movimiento de la clase base
    }
    public override void MoveToPosition(Vector3 pos)
    {
        base.MoveToPosition(pos);
    }
   /*/ public override void MoveToEnemy()
    {
        base.MoveToEnemy( );
    }*/
    public override void MoveToAllied()
    {
        base.MoveToAllied( );
    }
    public override void MoveToEvadEnemy()
    {
        base.MoveToEvadEnemy( );
    }
  
    /*
    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;
        if (normales != Vector3.zero)
        {
            Gizmos.DrawLine(health.AimOffset.position, health.AimOffset.position + normales * 2f);
            Gizmos.DrawSphere(health.AimOffset.position + normales * 2f, 0.5f);
        }
            
    }*/
}
