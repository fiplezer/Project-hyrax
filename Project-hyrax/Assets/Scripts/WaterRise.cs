using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public float speed = 0.1f;
    public bool Rise = false;

    public void Activate()
    {
        Rise = true;
    }

    void Update()
    {
        if (Rise == true)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
    public void Deactivate()
    {
        Rise = false;
    }
}