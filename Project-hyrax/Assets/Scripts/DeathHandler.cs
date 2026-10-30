using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    private int totalLives;
    private int currentLives;

    public Checkpoint CurrentCheckPoint;

    private void Start()
    {
        currentLives = totalLives;
    }

    //needs total lives, life ui
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Die(other);
        }
    }

    private void Die(Collider Player)
    {
        if (currentLives > 0)
        {
            Player.gameObject.transform.position = CurrentCheckPoint.gameObject.transform.position;
            //die & respawn
            //respawn player at correct checkpoint
            Debug.Log("You Died");
        }
        else if (currentLives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetCheckpoint(Checkpoint CP)
    {
        CurrentCheckPoint = CP;
    }
}
