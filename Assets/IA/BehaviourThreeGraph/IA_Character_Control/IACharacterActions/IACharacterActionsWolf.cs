using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsWolf : IACharacterActions
{

    public float FrameRate = 0;
    public float Rate=1;
    public int damageGallina;
    private void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    public void Attack()
    {
         
        if(FrameRate>Rate)
        {
            FrameRate = 0;
            IAEyeNPCAttack _IAEyeGallinaAttack = ((IAEyeNPCAttack)AIEye);
            
            if (_IAEyeGallinaAttack != null &&
                _IAEyeGallinaAttack.ViewEnemy != null)
            {

                _IAEyeGallinaAttack.ViewEnemy.Damage(damageGallina, health);
            }
            
        }
        FrameRate += Time.deltaTime;


    }
}
