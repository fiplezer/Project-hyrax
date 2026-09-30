using UnityEngine;

public class ActivateFog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fog = true;
    }
}
