using System.Collections;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public float speed = 0.1f;
    public bool Rise = false;
    public bool Lower = false;
    private bool Once = true;

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
        Rise = false;
        Lower = false;
        Vector3 pos = transform.position;
        pos.y = Mathf.MoveTowards(pos.y, -1.4f, 2f * Time.deltaTime);
        transform.position = pos;
    }

    IEnumerator waitTwentyFiveSeconds()
    {
        yield return new WaitForSeconds(25);

        Lower = false;
        Rise = true;
    }
}