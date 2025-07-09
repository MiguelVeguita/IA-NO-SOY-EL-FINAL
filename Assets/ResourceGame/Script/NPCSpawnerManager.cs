using UnityEngine;
using UnityEngine.EventSystems;

public class NPCSpawnerManager : MonoBehaviour
{
    public GameObject perroPrefab;
    public GameObject loboPrefab;
    public GameObject gallinaPrefab;

    private GameObject selectedPrefab;

    void Update()
    {
        // Si tienes seleccionado un prefab y das click izquierdo en el terreno
        if (selectedPrefab != null && Input.GetMouseButtonDown(0))
        {
            // Evitar colocar sobre un botón u otra UI
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Suponiendo que tu terreno tiene un collider
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Instantiate(selectedPrefab, hit.point, Quaternion.identity);
                selectedPrefab = null; // Comentar esto si quieres seguir colocando más de ese tipo
            }
        }
    }

    // Llamar desde los botones
    public void SelectPerro()
    {
        selectedPrefab = perroPrefab;
    }
    public void SelectLobo()
    {
        selectedPrefab = loboPrefab;
    }
    public void SelectGallina()
    {
        selectedPrefab = gallinaPrefab;
    }
}
