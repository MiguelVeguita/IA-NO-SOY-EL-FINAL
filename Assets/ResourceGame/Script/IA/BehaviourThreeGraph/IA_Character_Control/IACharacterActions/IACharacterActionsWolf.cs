using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsWolf : AICharacterActionsCaninus
{
    IAEyeNPCAttackWolf _IAEyeAttack;
    Hunger hunger;
    public int EatingValue;
    private void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        _IAEyeAttack = ((IAEyeNPCAttackWolf)AIEye);
        hunger=GetComponent<Hunger>();
    }
    public override void Damage()
    {
        if (_IAEyeAttack != null &&
                   _IAEyeAttack.ViewFood != null &&
                   _IAEyeAttack.AttackDataViewItem.Sight)
        {
            _IAEyeAttack.ViewFood.Damage(damage, health);
        }

    }
    public override void DamageEating()
    {
        if (_IAEyeAttack != null &&
                   _IAEyeAttack.ViewFood != null &&
                   _IAEyeAttack.AttackDataViewItem.Sight)
        {
            healtGallina item = ((healtGallina)_IAEyeAttack.ViewFood);
            item.DiscountFood(EatingValue, hunger);
        }

    }

}
