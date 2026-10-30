 using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform RespawnPoint;

    // Set the Player Character in GameMode
    //protected GameObject PlayerCharacter;

    public virtual void Start()
    { }

    public void Interact(GameObject CallSource)
    {
        // Set Respawn Point
        CallSource.GetComponent<DeathHandler>().SetCheckpoint(this);
        //PlayerCharacter = CallSource;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Interact(collision.gameObject);
        }
    }
}

