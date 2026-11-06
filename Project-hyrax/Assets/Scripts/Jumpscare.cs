using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] private GameObject jumpScareImage;
    private float jumpScareTimer;
    [SerializeField] private float jumpScareTime = 1f;
    [SerializeField] private AudioSource JumpscareSound;
    [SerializeField] private AudioSource HitSound;

    GameObject player;
    GameObject deathHandler;
    int currentLives;
    GameObject[] Hearts;
    public Transform angelRespawn;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathHandler = GameObject.FindGameObjectWithTag("DeathHandler");
        Hearts = deathHandler.GetComponent<DeathHandler>().Hearts;


        if (jumpScareImage)
        {
            jumpScareImage.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        jumpScareTimer += Time.deltaTime;

        if (jumpScareTimer > jumpScareTime)
        {
            currentLives = deathHandler.GetComponent<DeathHandler>().currentLives;
            if (currentLives > 0)
            {
                HitSound.Play();
                --currentLives;
                deathHandler.GetComponent<DeathHandler>().currentLives = currentLives;
                Hearts[currentLives].SetActive(false);
            }
            else if (currentLives <= 0)
            {
                player.GetComponent<CharacterController>().enabled = false;
                jumpScareImage.SetActive(true);
                JumpscareSound.Play();
                StartCoroutine(WaitForSeconds(2f));
            }
            // teleport angel away
            GetComponent<NavMeshAgent>().Warp(angelRespawn.position);
            jumpScareTimer = 0;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        jumpScareTimer = 0;
    }

    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
