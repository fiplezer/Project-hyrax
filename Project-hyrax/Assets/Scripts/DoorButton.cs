using UnityEngine;
using System.Threading;
using System.Collections;

public class DoorButton : MonoBehaviour, IInteractable
{
    public GameObject Door1;
    public GameObject Door2;
    public void Interact()
    {
        Door1.GetComponent<DoorController>().ToggleDoor();
        Door2.GetComponent<DoorController>().ToggleDoor();
    }
}
