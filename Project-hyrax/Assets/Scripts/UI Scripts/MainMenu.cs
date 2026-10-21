using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayPress()
    {
        SceneManager.LoadScene(+1);
    }
    public void OnQuitPress()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
