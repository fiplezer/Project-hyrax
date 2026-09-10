using UnityEngine;
using UnityEngine.AI;

public class WeepingAngel : MonoBehaviour
{
    [SerializeField] Renderer boundingArea;
    [SerializeField] LayerMask ignoreOnCheck;

    NavMeshAgent agent;
    Transform player;
    Camera playerCamera;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

        playerCamera = Camera.main;
    }

    void Update()
    {
        if (CanMove())
        {
            agent.destination = player.position;
        }
        else
        {
            agent.ResetPath();
        }
    }

    private bool CanMove()
    {
        if (playerCamera == null)
            return true;

        Vector3 viewportPosition =
            playerCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.z <= 0)
            return true;

        bool insideCameraView =
            viewportPosition.x >= 0f &&
            viewportPosition.x <= 1f &&
            viewportPosition.y >= 0f &&
            viewportPosition.y <= 1f;

        if (!insideCameraView)
            return true;

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
                return true;
            }
        }

        return false;
    }
}
