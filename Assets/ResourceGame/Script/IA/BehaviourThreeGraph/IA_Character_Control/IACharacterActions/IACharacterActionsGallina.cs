using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsGallina : IACharacterActions
{
    IAEyeGallina _IAEyeAttack;
    public int EatingValue;
    void Awake()
    {
       
        LoadComponent();
    }


    public override void LoadComponent()
    {
        base.LoadComponent();
        _IAEyeAttack = ((IAEyeGallina)AIEye);
    }
    public override void DamageEating()
    {
        if (_IAEyeAttack != null &&
            _IAEyeAttack.ViewFood != null &&
            _IAEyeAttack.EatDataView.Sight)
        {
            if (FrameRateEating > RateEating)
            {
                FrameRateEating = 0;
                healtPan item = ((healtPan)_IAEyeAttack.ViewFood);
                item.DiscountFood(EatingValue, hunger);
            }
            FrameRateEating += Time.deltaTime;
        }
    }

}
