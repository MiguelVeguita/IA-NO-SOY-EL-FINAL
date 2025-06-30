using UnityEngine;

public class AICharacterActionsCaninus : IACharacterActions
{
    protected float FrameRate = 0;
    public float Rate = 1;
    public int damage;
    protected IAEyeNPCAttack _IAEyeAttack;
    
    public override void LoadComponent()
    {
        base.LoadComponent();
        _IAEyeAttack = ((IAEyeNPCAttack)AIEye);
        _CharacterAnimationBase = GetComponent<CharacterCaninus>();
    }
    public void Damage()
    {
        if (_IAEyeAttack != null &&
                   _IAEyeAttack.ViewEnemy != null &&
                   _IAEyeAttack.AttackDataView.Sight)
        {
            _IAEyeAttack.ViewEnemy.Damage(damage, health);
        }

    }
    public void Attack()
    {

        if (FrameRate > Rate)
        {
            FrameRate = 0;
            ((CharacterCaninus)_CharacterAnimationBase).Attack();
        }
        FrameRate += Time.deltaTime;


    }

}
