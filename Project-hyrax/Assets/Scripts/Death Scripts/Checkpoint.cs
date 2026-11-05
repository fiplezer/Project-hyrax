 using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject deathHandler;

    // Set the Player Character in GameMode
    //protected GameObject PlayerCharacter;

    private void Start()
    {
        deathHandler = GameObject.FindGameObjectWithTag("DeathHandler");
    }

    public void SetCheckpoint(GameObject collisionObject)
    {
        // Set Respawn Point
        deathHandler.GetComponent<DeathHandler>().SetCheckpoint(this);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            SetCheckpoint(collision.gameObject);
        }
    }
}

