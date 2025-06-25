// Archivo: Assets/IA/BehaviourThreeGraph/ActionNode/NodeMove/MoveToFood.cs (REEMPLAZAR)

using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI; // Asegúrate de tener este 'using'

[TaskCategory("MyAI/Move")]
[TaskDescription("Mueve al personaje hacia el FoodItem que ha detectado y devuelve Success al llegar.")]
public class MoveToFood : ActionNodeVehicle
{
    public override TaskStatus OnUpdate()
    {
        // --- Verificaciones iniciales ---
        if (_IACharacterVehiculo == null || _IACharacterVehiculo.agent == null)
        {
            Debug.LogError("MoveToFood: El NavMeshAgent no está asignado.");
            return TaskStatus.Failure;
        }
        if (_IACharacterVehiculo.AIEye == null || _IACharacterVehiculo.AIEye.ViewFood == null)
        {
            // Si pierde de vista la comida mientras se mueve, falla la tarea.
            _IACharacterVehiculo.agent.isStopped = true; // Detenemos al agente
            return TaskStatus.Failure;
        }

        NavMeshAgent agent = _IACharacterVehiculo.agent;
        Vector3 foodPosition = _IACharacterVehiculo.AIEye.ViewFood.transform.position;

        // --- Lógica de Movimiento y Llegada ---
        // Si el destino del agente no es la comida, se lo asignamos.
        if (agent.destination != foodPosition)
        {
            agent.SetDestination(foodPosition);
            agent.isStopped = false; // Asegurarse de que se mueva
        }

        // --- Comprobación de llegada (la parte importante) ---
        // `pathPending` es true mientras el agente calcula la ruta. No debemos comprobar la distancia aún.
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log("MoveToFood: ¡Hemos llegado a la comida! Devolviendo Success.");
                    // Ha llegado. La tarea termina con éxito para que el árbol pase a la siguiente (comer).
                    return TaskStatus.Success;
                }
            }
        }

        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        
        if (_IACharacterVehiculo != null && _IACharacterVehiculo.agent != null && _IACharacterVehiculo.agent.hasPath)
        {
            _IACharacterVehiculo.agent.isStopped = true;
        }
    }
}