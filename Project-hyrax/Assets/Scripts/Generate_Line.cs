using UnityEngine;

public class Generate_Line : MonoBehaviour, IInteractable
{
    private LijnPuzzel LijnPuzzelScript;
    public void Interact()
    {
        ResetLine();
    }

    public void ResetLine()
    {
        LijnPuzzelScript = transform.parent.GetComponentInParent<LijnPuzzel>();
        transform.parent.GetComponentInChildren<Select_Color>().ResetColor();

        foreach (GameObject target in  LijnPuzzelScript.targets)
        {
            target.GetComponent<Generate_Color>().ResetColor();
        }

        LijnPuzzelScript.CreateLine();
    }
}
