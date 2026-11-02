using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    private void OnTriggerEnter(Collider other)
    {
        Door1.GetComponent<DoorController>().ToggleDoor();
        Door2.GetComponent<DoorController>().ToggleDoor();
        this.gameObject.SetActive(false);
    }
}
