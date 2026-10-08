using UnityEngine;

public class Generate_Color : MonoBehaviour, IInteractable
{
    public ColorScriptableObject[] colors;
    [HideInInspector] public ColorScriptableObject randomScriptableObject;

    private LineRenderer line;
    private Renderer rend;

    public bool Interacted = false;

    void Start()
    {
        line = transform.parent.GetComponentInParent<LijnPuzzel>().line;
        rend = GetComponent<Renderer>();
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
        rend.material.color = Color.gray;
        randomScriptableObject = null;
    }
}
