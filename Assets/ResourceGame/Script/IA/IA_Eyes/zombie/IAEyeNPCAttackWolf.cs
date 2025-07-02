using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeNPCAttackWolf : IAEyeBase
{
    public DataView AttackDataViewItem = new DataView();
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
        if (ViewFood != null)
            AttackDataViewItem.IsInSight(ViewFood.AimOffset);
        else
        {
            AttackDataViewItem.Sight = false;
            mainDataView.Sight = false;
        }

    }

    private void OnValidate()
    {
        mainDataView.CreateMesh();
        AttackDataViewItem.CreateMesh();
        EatDataView.CreateMesh();
    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        AttackDataViewItem.OnDrawGizmos();
        EatDataView.OnDrawGizmos();
    }
}
