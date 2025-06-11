using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoGallina : IACharacterVehiculo
{
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
