
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine; // Añadir para usar Vector3

[TaskCategory("MyAI/Action")]
[TaskDescription("Consume el FoodItem cercano para restaurar el hambre.")]
public class EatFood : ActionNodeAction
{
    public float maxEatDistance = 2.0f; 

    public override TaskStatus OnUpdate()
    {
        if (_IACharacterActions == null) return TaskStatus.Failure;

        //Hunger hungerSystem = _IACharacterActions.hunger;
        //FoodItem foodItem = _IACharacterActions.AIEye.ViewFood;

        //if (hungerSystem != null && foodItem != null)
        //{
        //    // --- NUEVA COMPROBACIÓN DE DISTANCIA ---
        //    float distanceToFood = Vector3.Distance(_IACharacterActions.transform.position, foodItem.transform.position);

        //    if (distanceToFood > maxEatDistance)
        //    {
        //        // Si por alguna razón intenta comer pero está muy lejos, la acción falla.
        //        // Esto previene que la gallina coma "a distancia".
        //        Debug.LogWarning("EatFood: Intento de comer pero está muy lejos. Distancia: " + distanceToFood);
        //        return TaskStatus.Failure;
        //    }
        //    // --- FIN DE LA COMPROBACIÓN ---

        //    Debug.Log("EatFood: Comiendo... Hambre restaurada: " + foodItem.hungerRestoreAmount);
        //    hungerSystem.Eat(foodItem.hungerRestoreAmount);
        //    foodItem.Consume();
        //    _IACharacterActions.AIEye.ViewFood = null;

        //    return TaskStatus.Success;
        //}

        return TaskStatus.Failure;
    }
}