using UnityEngine;

public class IACharacterCaninus : IACharacterVehiculo
{
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    public override void MoveToWander()
    {
        base.MoveToWander();
    }
    public override void MoveToEnemy()
    {
        base.MoveToEnemy();
    }
     
    public override void MoveToAllied()
    {
        base.MoveToAllied();
    }
    public override void MoveToEvadEnemy()
    {
        //if (AIEye.ViewEnemy == null) return;
        //Vector3 dir = (transform.position - AIEye.ViewEnemy.transform.position).normalized;
        //Vector3 newPosition = transform.position + dir * 5f;
        //MoveToPosition(newPosition);
    }

     
}
