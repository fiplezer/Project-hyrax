using System.Collections;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public float speed = 0.1f;
    public bool Rise = false;
    public bool Lower = false;
    public bool Once = true;

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

        if (Lower == true && Once == true)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            StartCoroutine(waitTwentyFiveSeconds());
            Once = false;
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

    public void WaterDone()
    {
        Once = false;
        Lower = false;
        Rise = false;

        IEnumerator LowerPlane(float targetY, float duration)
        {
            Vector3 startPos = transform.position;
            Vector3 targetPos = new Vector3(startPos.x, targetY, startPos.z);

            float elapsed = 0f;

            while (elapsed < duration)
            {
                transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;
        }
    }

    IEnumerator waitTwentyFiveSeconds()
    {
        yield return new WaitForSeconds(25);

        Once = true;
        Lower = false;
        Rise = true;
    }
}