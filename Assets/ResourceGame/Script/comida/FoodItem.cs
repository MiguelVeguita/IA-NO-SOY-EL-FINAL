// Archivo: FoodItem.cs (puedes crearlo en una carpeta "Scripts/Items" o donde prefieras)

using UnityEngine;

public class FoodItem : Health
{
    [Tooltip("Cantidad de hambre que este item restaura.")]
    public int hungerRestoreAmount;
    private void Awake()
    {
        base.LoadComponent();    
    }

}