using UnityEngine;

public class Generate_Line : MonoBehaviour, IInteractable
{
    public Transform lijnpuzzel;
    private LijnPuzzel LijnPuzzelScript;
    public void Interact()
    {
        //turn on/off lijnpuzzel script
        //get lijnpuzzel script
        LijnPuzzelScript = lijnpuzzel.GetComponent<LijnPuzzel>();

        if (LijnPuzzelScript.enabled == true)
        {
            LijnPuzzelScript.enabled = false;
        }
        else
        {
            LijnPuzzelScript.enabled = true;
        }
    }
}
