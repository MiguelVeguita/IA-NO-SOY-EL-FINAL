using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeNPCAttackDog : IAEyeBase
{
    public DataView AttackDataViewEnemy = new DataView();
    private void Awake()
    {
        LoadComponent();
    }

    private void Update()
    {
        UpdateScan();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }


    public override void UpdateScan()
    {
        base.UpdateScan();
        if (ViewEnemy != null)
            AttackDataViewEnemy.IsInSight(ViewEnemy.AimOffset);
        else
        {
            AttackDataViewEnemy.Sight = false;
            mainDataView.Sight = false;
        }

    }

    private void OnValidate()
    {
        mainDataView.CreateMesh();
        AttackDataViewEnemy.CreateMesh();
        EatDataView.CreateMesh();
    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        AttackDataViewEnemy.OnDrawGizmos();
        EatDataView.OnDrawGizmos();
    }
}
