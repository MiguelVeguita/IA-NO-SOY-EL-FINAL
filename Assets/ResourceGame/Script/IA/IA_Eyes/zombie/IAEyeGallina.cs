using UnityEngine;

public class IAEyeGallina : IAEyeBase
{
    private void Start()
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
            EatDataView.IsInSight(ViewFood.AimOffset);
        else
        {
            EatDataView.Sight = false;
            mainDataView.Sight = false;
        }

    }

    private void OnValidate()
    {
        mainDataView.CreateMesh();
        EatDataView.CreateMesh();
    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        EatDataView.OnDrawGizmos();

    }



}
