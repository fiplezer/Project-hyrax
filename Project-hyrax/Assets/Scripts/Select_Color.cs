using UnityEngine;

public class Select_Color : MonoBehaviour, IInteractable
{
    public ColorScriptableObject[] colors;
    private ColorScriptableObject scriptableObject;
    private int number = 0;

    public void Interact()
    {
        if (number <= colors.Length)
        {
            number++;
        }
        else
        {
            number = 0;
        }
        scriptableObject = colors[number];
        GetComponent<Renderer>().material.SetColor("_Base   Color", scriptableObject.color);
        Debug.Log(number);
    }
}
