
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("MyAI/View")]
[TaskDescription("Verifica si el personaje ha detectado un FoodItem con su IAEye.")]
public class CanSeeFood : ActionNodeView // Usamos tu clase base ActionNodeView
{
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo != null && _IACharacterVehiculo.AIEye != null)
        {
            if (_IACharacterVehiculo.AIEye.ViewFood != null)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}