using UnityEngine;

public class Select_Color : MonoBehaviour, IInteractable
{
    public ColorScriptableObject[] colors;
    public ColorScriptableObject scriptableObject;

    private Renderer lightRenderer;

    private int number = 0;

    void Start()
    {
        lightRenderer = transform.GetChild(0).gameObject.GetComponent<Renderer>();
    }

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
        lightRenderer.material.color = scriptableObject.color;
    }

    public void ResetColor()
    {
        lightRenderer.material.color = Color.gray;
        scriptableObject = null;
    }
}
