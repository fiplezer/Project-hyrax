using System.Threading;
using UnityEngine;

public class Temp_Turning_script : MonoBehaviour, IInteractable
{
    float timer = 0f;
    void Update()
    {
        timer -= Time.deltaTime;
    }
    public void Interact()
    {
        if(timer <= 0)
        {
            transform.Rotate(0, -90, 0);
            timer = 1f;
        }
    }
}
