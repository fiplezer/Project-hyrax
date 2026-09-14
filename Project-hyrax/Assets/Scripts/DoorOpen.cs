using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject Holder1;
    public GameObject Holder2;
    public GameObject Holder3;
    private void Update()
    {
        if (Holder1.gameObject.transform.eulerAngles.y == 90f)
        {

        }
    }
}
