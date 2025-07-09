using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healtGallina : Health
{
    public GameObject GallinaModel;
    public GameObject MusloModel;
    private void Awake()
    {
        LoadComponent();
        if (GallinaModel) GallinaModel.SetActive(true);
        if (MusloModel) MusloModel.SetActive(false);
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
       
    }

   
    private void Update()
    {
        if (IsDead)
        {
            OnDeathVisual();
        }
        if (!IsCountFood)
        {
          //  Destroy(this.gameObject);
        }
    }

    private void OnDeathVisual()
    {
        if (GallinaModel) GallinaModel.SetActive(false);
        if (MusloModel) MusloModel.SetActive(true);
    }
}
