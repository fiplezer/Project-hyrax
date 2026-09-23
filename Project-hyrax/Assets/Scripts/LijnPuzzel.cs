using UnityEngine;
using UnityEngine.AI;

public class LijnPuzzel : MonoBehaviour
{
    private LineRenderer line; //to hold the line Renderer
    public Transform target; //to hold the transform of the target
    private NavMeshAgent agent; //to hold the agent of this gameObject
    private NavMeshPath paths;

    void Start()
    {
        line = GetComponent<LineRenderer>(); //get the line renderer
        agent = GetComponent<NavMeshAgent>(); //get the agent
        paths = new NavMeshPath();
        getPath();
    }

    private void getPath()
    {
        line.SetPosition(0, transform.position); //set the line's origin

        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, paths);

        DrawPath(paths);

        agent.isStopped = true;  //add this if you don't want to move the agent
    }

    private void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        line.positionCount = path.corners.Length; //set the array of positions to the amount of corners

        for (var i = 1; i < path.corners.Length; i++)
        {
            Vector3 linePath = new Vector3(path.corners[i].x, path.corners[i].y + 3, path.corners[i].z);
            line.SetPosition(i, linePath); //go through each corner and set that to the line renderer's position
        }
    }
}
