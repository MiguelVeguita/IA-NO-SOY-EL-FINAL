using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsDog : AICharacterActionsCaninus
{

    IAEyeNPCAttackDog _IAEyeAttack;
    private void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        _IAEyeAttack = ((IAEyeNPCAttackDog)AIEye);
    }
    public override void Damage()
    {
        if (FrameRate > Rate)
        {
            FrameRate = 0; 

            if (_IAEyeAttack != null &&
                _IAEyeAttack.ViewEnemy != null &&
                _IAEyeAttack.AttackDataViewEnemy.Sight)
            {
                _IAEyeAttack.ViewEnemy.Damage(damage, health);
            }
        }
        FrameRate += Time.deltaTime;

    }
}
