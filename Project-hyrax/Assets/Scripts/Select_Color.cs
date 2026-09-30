using UnityEngine;

public class Select_Color : MonoBehaviour, IInteractable
{
    public ColorScriptableObject[] colors;
    private ColorScriptableObject scriptableObject;
    private int number = 0;
    [SerializeField] private GameObject ColorSelectLight;

    public void Interact()
    {
        if (number == colors.Length - 1)
        {
            number = 0;
        }
        else
        {
            number++;
        }
        scriptableObject = colors[number];
        ColorSelectLight.GetComponent<Renderer>().material.color = scriptableObject.color;
    }
}
