using UnityEngine;

public class Die : MonoBehaviour
{
    private GameObject deathHandler;

    private void Start()
    {
        deathHandler = GameObject.FindGameObjectWithTag("DeathHandler");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            deathHandler.GetComponent<DeathHandler>().Die(collision);
        }
    }
}
