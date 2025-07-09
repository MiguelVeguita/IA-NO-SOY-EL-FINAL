using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangueScene : MonoBehaviour
{
   public void Changuescene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
