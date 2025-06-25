// Archivo: FoodItem.cs (puedes crearlo en una carpeta "Scripts/Items" o donde prefieras)

using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [Tooltip("Cantidad de hambre que este item restaura.")]
    public int hungerRestoreAmount; 

    /// <summary>
    /// Este método se llamará cuando la gallina consuma el item.
    /// </summary>
    public void Consume()
    {
        // La acción más simple es destruir el objeto de comida.
        Destroy(gameObject);
    }
}