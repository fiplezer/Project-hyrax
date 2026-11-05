using UnityEngine;

public class Generate_Color : MonoBehaviour, IInteractable
{
    public ColorScriptableObject[] colors;
    [HideInInspector] public ColorScriptableObject randomScriptableObject;

    private LineRenderer line;
    private Renderer rend;

    public bool Interacted = false;

    private Color startColor;

    void Start()
    {
        line = transform.parent.GetComponentInParent<LijnPuzzel>().line;
        rend = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void Interact()
    {
        if (!Interacted && this.gameObject.transform == transform.parent.GetComponentInParent<LijnPuzzel>().target)
        {
            Interacted = true;

            int randomNumber = Random.Range(0, colors.Length);
            randomScriptableObject = colors[randomNumber];
            rend.material.color = randomScriptableObject.color;

            line.enabled = false;
        }
    }

    public void ResetColor()
    {
        Interacted = false;
        rend.material.color = startColor;
        randomScriptableObject = null;
    }
}
