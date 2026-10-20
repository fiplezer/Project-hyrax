using System.Threading;
using UnityEngine;

public class Temp_Turning_script : MonoBehaviour, IInteractable
{
    float timer = 0f;
    public int value = 0;
    void Update()
    {
        timer -= Time.deltaTime;
    }
    public void Interact()
    {
        if(timer <= 0)
        {
            transform.Rotate(0, -90, 0);
            value = (value + 1) % 4;
            timer = 1f;
        }
    }
}
