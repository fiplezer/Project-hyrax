using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private int totalLives;
    [SerializeField] private int currentLives;

    public Checkpoint CurrentCheckPoint;
    private GameObject water;

    private void Start()
    {
        currentLives = totalLives;
        water = GameObject.FindGameObjectWithTag("Water");
    }

    public void Die(Collider Player)
    {
        if (currentLives > 0)
        {
            Player.gameObject.GetComponent<CharacterController>().enabled = false;
            Player.gameObject.transform.position = CurrentCheckPoint.gameObject.transform.position;
            Player.gameObject.GetComponent<CharacterController>().enabled = true;

            //reset water to start position

            water.transform.position = water.GetComponent<WaterRise>().startPosition;



            --currentLives;
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
