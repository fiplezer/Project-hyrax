using UnityEngine;
using UnityEngine.AI;

public class LijnPuzzel : MonoBehaviour
{
    [HideInInspector] public LineRenderer line;
    [HideInInspector] public Transform target;
    private Transform previousTarget;
    private NavMeshAgent agent;
    private NavMeshPath paths;
    public GameObject[] targets; //required for Generate_Line
    public Transform[] transformTargets;

    void Awake()
    {
        if (line == null)
        {
            line = GetComponentInChildren<LineRenderer>();
        }
        if (agent == null)
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }

        CreateLine();
    }

    public void CreateLine()
    {
        if (targets.Length == 0)
        {
            targets = GameObject.FindGameObjectsWithTag("Finish");
            transformTargets = new Transform[targets.Length];
            for (int i = 0; i < targets.Length; i++)
            {
                transformTargets[i] = targets[i].transform;
            }
        }

        if (previousTarget == null)
        {
            int index = Random.Range(0, targets.Length);
            target = transformTargets[index];
            previousTarget = target;
        }
        else
        {
            while (target == previousTarget)
            {
                int index = Random.Range(0, targets.Length);
                target = transformTargets[index];
            }
            previousTarget = target;
        }

        if (line.enabled == false)
        {
            line.enabled = true;
        }

        paths = new NavMeshPath();
        getPath();
    }

    private void getPath()
    {
        line.SetPosition(0, transform.position); 

        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, paths);

        DrawPath(paths);

        line.gameObject.transform.eulerAngles = new Vector3(90f,0f,0f);
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
