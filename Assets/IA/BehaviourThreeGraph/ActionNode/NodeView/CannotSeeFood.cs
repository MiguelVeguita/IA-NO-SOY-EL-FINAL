// Archivo: Assets/IA/BehaviourThreeGraph/ActionNode/NodeView/CannotSeeFood.cs

using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("MyAI/View")]
[TaskDescription("Verifica si el personaje NO ha detectado un FoodItem con su IAEye.")]
public class CannotSeeFood : ActionNodeView // Heredamos de la misma clase base
{
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo != null && _IACharacterVehiculo.AIEye != null)
        {
            // La lógica es la inversa de CanSeeFood:
            if (_IACharacterVehiculo.AIEye.ViewFood == null) // << La condición clave es '== null'
            {
                // ¡Éxito! La gallina NO ve comida.
                return TaskStatus.Success;
            }
        }

        // Si ve comida, esta condición falla.
        return TaskStatus.Failure;
    }
}