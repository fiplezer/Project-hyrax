using UnityEngine;

public class Check_Matching_Colors : MonoBehaviour, IInteractable
{
    private GameObject currentTarget;
    public GameObject currentSelectedColorObject;
    public GameObject lineGenerator;
    private ColorScriptableObject targetScriptableObject;
    private ColorScriptableObject selectedScriptableObject;

    [SerializeField] private GameObject End;

    public GameObject[] PointLights;
    private int requiredPoints;
    private int currentPoints;

    private void Awake()
    {
        End = GameObject.FindGameObjectWithTag("End");
        End.SetActive(false);
        requiredPoints = PointLights.Length;
    }

    public void Interact()
    {
        currentTarget = transform.parent.GetComponentInParent<LijnPuzzel>().target.gameObject;
        
        if (currentTarget.GetComponent<Generate_Color>().randomScriptableObject == null || currentSelectedColorObject.GetComponent<Select_Color>().scriptableObject == null)
        {
            ResetAll();
            return;
        }
        else
        {
            targetScriptableObject = currentTarget.GetComponent<Generate_Color>().randomScriptableObject;
            selectedScriptableObject = currentSelectedColorObject.GetComponent<Select_Color>().scriptableObject;
        }

        if (targetScriptableObject.ID == selectedScriptableObject.ID)
        {
            currentPoints++;
            if (currentPoints <= requiredPoints)
            {
                PointLights[currentPoints - 1].GetComponent<Renderer>().material.color = Color.green;
            }

            if (currentPoints >= requiredPoints)
            {
                End.SetActive(true);
                Debug.Log("Win");
            }
            ResetAll();
        }
        else
        {
            ResetAll();
        }
    }

    private void ResetAll()
    {
        currentTarget.GetComponent<Generate_Color>().ResetColor();
        currentSelectedColorObject.GetComponent <Select_Color>().ResetColor();
        lineGenerator.GetComponent<Generate_Line>().ResetLine();
    }
}
