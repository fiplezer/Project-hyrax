using UnityEngine;

public class PlankUp : MonoBehaviour
{
    [Header("Components")]
    public Animator plankAnimator;
    public GameObject Valve1;
    public GameObject Valve2;
    public GameObject Valve3;
    public GameObject Valve4;

    private bool Turned1;
    private bool Turned2;
    private bool Turned3;

    public void BridgeDown()
    {
        plankAnimator.SetTrigger("Activate");
    }
}
