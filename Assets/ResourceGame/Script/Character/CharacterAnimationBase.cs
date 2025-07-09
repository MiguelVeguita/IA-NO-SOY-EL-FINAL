using UnityEngine;
using UnityEngine.AI;
public enum StateAnimator
{
    Death,
    Attack,
    Eating,
    IdleWalkRun,
    None
}
[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class CharacterAnimationBase : MonoBehaviour
{
    protected Animator animator;
    protected NavMeshAgent agent;
    protected float maxSpeed;

    protected Health health;
    public StateAnimator _StateAnimatior;
    public virtual void LoadComponent()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        maxSpeed = agent.speed;
    }

     

    protected void UpdateAnimation()
    {
        if (animator == null || agent == null) return;

        float speedPercent = agent.velocity.magnitude / maxSpeed;
        animator.SetFloat("Forward", speedPercent);

       
    }

    // Métodos para animaciones de acciones
    
     

    public void Eat()
    {
        animator.SetBool("Eat", true);
        
    }

    

    public void Death()
    {
        animator.SetBool("Death", true);
    }
}
