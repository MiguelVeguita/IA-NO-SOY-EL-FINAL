using UnityEngine;

public class CharacterChicken : CharacterAnimationBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead) return;
        UpdateAnimation();
    }
}
