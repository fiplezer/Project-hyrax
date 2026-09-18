using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Gnome : MonoBehaviour
{
    [SerializeField] LayerMask ignoreOnCheck;

    NavMeshAgent agent;
    Transform player;
    Camera playerCamera;

    public float range = 10.0f;
    private bool moving = false;

    public AudioSource GnomeSound;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

        playerCamera = Camera.main;
    }

    void Update()
    {
        if (IsSpotted() && moving == false)
        {
            StartCoroutine(RunAway());
        }
    }

    private bool IsSpotted()
    {
        if (playerCamera == null)
            return false;

        Vector3 viewportPosition =
            playerCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.z < 0)
            return false;

        bool insideCameraView =
            viewportPosition.x >= 0f &&
            viewportPosition.x <= 1f &&
            viewportPosition.y >= 0f &&
            viewportPosition.y <= 1f;

        if (!insideCameraView)
            return false;

        Vector3 direction =
            transform.position - playerCamera.transform.position;

        float distance = direction.magnitude;

        direction.Normalize();

        if (Physics.Raycast(
            playerCamera.transform.position,
            direction,
            out RaycastHit hit,
            distance,
            ~ignoreOnCheck))
        {
            if (hit.transform != transform &&
                !hit.transform.IsChildOf(transform))
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerator RunAway()
    {
        moving = true;
        yield return new WaitForSeconds(Random.Range(0f, 3f));

        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            GnomeSound.Play();
            agent.destination = point;
            yield return new WaitForSeconds(5f);
        }

        Destroy(this.gameObject);

    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        randomPoint = new Vector3(randomPoint.x, 0, randomPoint.z);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 2.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}