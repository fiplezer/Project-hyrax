using UnityEngine;
using UnityEngine.AI;

public class LijnPuzzel : MonoBehaviour
{
    private LineRenderer line;
    public Transform target;
    private NavMeshAgent agent;
    private NavMeshPath paths;

    void Start()
    {
        //create line stuff
        line = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        paths = new NavMeshPath();
        getPath();
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
