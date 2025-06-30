using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IACharacterActions : IACharacterControl
{
    protected float FrameRateEating = 0;
    public float RateEating = 1;
    public int damageEating;
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    public void DamageEating()
    {
        if (AIEye != null &&
                   AIEye.ViewFood != null &&
                   AIEye.EatDataView.Sight)
        {
            AIEye.ViewFood.Damage(damageEating, health);
        }

    }
    public void Eating()
    {

        if (FrameRateEating > RateEating)
        {
            FrameRateEating = 0;
            ((CharacterCaninus)_CharacterAnimationBase).Eat();
        }
        FrameRateEating += Time.deltaTime;


    }

}
