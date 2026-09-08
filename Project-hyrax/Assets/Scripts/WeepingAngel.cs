using UnityEngine;
using UnityEngine.AI;

public class WeepingAngel : MonoBehaviour
{
    [SerializeField] Renderer BoundingArea;
    [SerializeField] LayerMask ignoreOnCheck;
    [SerializeField] Animator anim;

    NavMeshAgent agent;
    Transform player;

    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (CanMove())
        {
            agent.destination = player.position;
        }
        else
        {
            agent.destination = this.transform.position;   
        }
    }

    private bool CanMove()
    {
        if (BoundingArea.isVisible)
        {
            return false;
        }

        return true;
    }
}
