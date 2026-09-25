using UnityEngine;

public class Generate_Color : MonoBehaviour, IInteractable
{
    public ColorScriptableObject[] colors;
    private ColorScriptableObject randomScriptableObject;

    public void Interact()
    {
        //get a random color and id from scriptable objects
        int randomNumber = Random.Range(0, colors.Length);
        randomScriptableObject = colors[randomNumber];
        GetComponent<Renderer>().material.SetColor("_BaseColor", randomScriptableObject.color);
        Debug.Log(randomScriptableObject.color);
        Debug.Log(randomScriptableObject.ID);
    }
}
