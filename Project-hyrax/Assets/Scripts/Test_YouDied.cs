using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_YouDied : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
