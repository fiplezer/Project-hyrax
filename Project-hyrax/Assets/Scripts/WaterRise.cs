using System.Collections;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public float speed = 0.1f;
    public bool Rise = false;
    public bool Lower = false;

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

        if (Lower == true)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            StartCoroutine(waitTwentySeconds());
        }
    }
    public void Deactivate()
    {
        Rise = false;
    }

    public void ActivateLower()
    {
        Rise = false;
        Lower = true;
    }

    IEnumerator waitTwentySeconds()
    {
        yield return new WaitForSeconds(20);

        Lower = false;
        Rise = true;
    }
}