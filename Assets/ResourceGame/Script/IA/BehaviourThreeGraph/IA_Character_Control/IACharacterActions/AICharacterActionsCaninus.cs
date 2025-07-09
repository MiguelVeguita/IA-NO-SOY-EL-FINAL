using UnityEngine;

public class AICharacterActionsCaninus : IACharacterActions
{
    protected float FrameRate = 0;
    public float Rate = 1;
    public int damage;
    
    public override void LoadComponent()
    {
        base.LoadComponent();
         
        _CharacterAnimationBase = GetComponent<CharacterCaninus>();
    }
    public virtual void Damage()
    {
         
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
    public void Update()
    {
        if (health.IsDead)
        {
            
           ((CharacterCaninus)_CharacterAnimationBase).Death();
            
        }
    }
    public override void Eating()
    {

        if (FrameRateEating > RateEating)
        {
            FrameRateEating = 0;
            ((CharacterCaninus)_CharacterAnimationBase).Eat();
        }
        FrameRateEating += Time.deltaTime;


    }
}
