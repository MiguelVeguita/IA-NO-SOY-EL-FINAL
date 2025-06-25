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

        
        float speedPercent = agent.velocity.magnitude / agent.speed;

       
        animator.SetFloat(verticalAnimatorID, speedPercent, 0.1f, Time.deltaTime);
    }
    public override void MoveToWander()
    {
        
        if (agent != null && agent.speed != patrolSpeed)
        {
            agent.speed = patrolSpeed;
        }
        base.MoveToWander(); 
    }
    public override void MoveToPosition(Vector3 pos)
    {
        base.MoveToPosition(pos);
    }
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
