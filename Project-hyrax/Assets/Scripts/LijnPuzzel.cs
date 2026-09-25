using UnityEngine;
using UnityEngine.AI;

public class LijnPuzzel : MonoBehaviour
{
    private LineRenderer line;
    private Transform target;
    private NavMeshAgent agent;
    private NavMeshPath paths;
    public GameObject[] targets;

    void OnEnable()
    {
        if (line  == null)
        {
            line = GetComponent<LineRenderer>();
        }
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        //get targets
        if (targets.Length == 0)
        {
            targets = GameObject.FindGameObjectsWithTag("Finish");
        }

        //search for new goal/target
        int index = Random.Range(0, targets.Length);
        Debug.Log(targets[index]);
        target = targets[index].GetComponent<Transform>();

        //create line stuff
        line.enabled = true;
        paths = new NavMeshPath();
        getPath();
    }

    private void OnDisable()
    {
        line.enabled = false;
    }

    private void getPath()
    {
        line.SetPosition(0, transform.position); 

        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, paths);

        DrawPath(paths);

        agent.enabled = false;
        transform.eulerAngles = new Vector3(90f,0f,0f);
    }

    private void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2)
            return;

        line.positionCount = path.corners.Length;

        for (var i = 1; i < path.corners.Length; i++)
        {
            Vector3 linePath = new Vector3(path.corners[i].x, path.corners[i].y, path.corners[i].z);
            line.SetPosition(i, linePath); 
        }
    }
}
