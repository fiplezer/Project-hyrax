using UnityEngine;

public class PlankUp : MonoBehaviour
{
    [Header("Components")]
    public Animator plankAnimator;
    public GameObject WaterObject;
    public GameObject Valve1;
    public GameObject Valve2;
    public GameObject Valve3;
    public GameObject Valve4;

    bool Turned1;
    bool Turned2;
    bool Turned3;
    bool Turned4;

    private void Update()
    {
        Valve valve1 = Valve1.GetComponent<Valve>();
        Valve valve2 = Valve2.GetComponent<Valve>();
        Valve valve3 = Valve3.GetComponent<Valve>();
        Valve valve4 = Valve4.GetComponent<Valve>();

        Turned1 = valve1.Turned;
        Turned2 = valve2.Turned;
        Turned3 = valve3.Turned;
        Turned4 = valve4.Turned;

        if(Turned1 == true && Turned2 == true && Turned3 == true && Turned4 == true)
        {
            WaterObject.GetComponent<WaterRise>().WaterDone();
            BridgeDown();
        }
    }

    public void BridgeDown()
    {
        plankAnimator.SetTrigger("Activate");
    }
}
