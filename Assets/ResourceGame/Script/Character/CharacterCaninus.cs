using UnityEngine;

public class CharacterCaninus : CharacterAnimationBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.IsDead) return;
        UpdateAnimation();
    }
    public void Attack()
    {
        animator.SetBool("Attack", true);
        
    }

}
