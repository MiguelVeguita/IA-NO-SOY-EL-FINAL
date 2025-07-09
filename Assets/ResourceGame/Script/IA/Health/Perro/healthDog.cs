using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healtDog : Health
{
    private void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    private void Update()
    {
       
        if (!IsCountFood)
        {
            Destroy(this.gameObject);
        }
    }
}
