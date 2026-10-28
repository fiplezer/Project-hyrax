using System.Collections;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public float speed = 0.1f;
    public bool Rise = false;
    public bool Lower = false;
    public bool HasStarted = false;

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
            
        }

        if(HasStarted == true)
        {
            StartCoroutine(waitTwentySeconds());
            HasStarted = false;
        }
    }
    public void Deactivate()
    {
        Rise = false;
    }

    public void ActivateLower()
    {
        HasStarted = true;
        Rise = false;
        Lower = true;
    }

    public void WaterDone()
    {
        Lower = false;
        Rise = false;
        LowerPlane(-1.4f, 6f);
    }

    IEnumerator waitTwentySeconds()
    {
        yield return new WaitForSeconds(20);

        Lower = false;
        Rise = true;
    }

    IEnumerator LowerPlane(float targetY, float duration)
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(startPos.x, targetY, startPos.z);

        float elapsed = 5f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }
}