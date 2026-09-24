using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public float targetHeight = 5f;
    public float riseSpeed = 1f;

    private bool rising = false;

    public void Activate()
    {
        rising = true;
    }

    public void Deactivate()
    {
        rising = false;
    }

    void Update()
    {
        if (rising == true)
        {
            Vector3 targetPosition = new Vector3(
                transform.position.x,
                targetHeight,
                transform.position.z
            );

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                riseSpeed * Time.deltaTime
            );
    
            if (Mathf.Approximately(transform.position.y, targetHeight))
            {
                rising = false;
            }
        }
    }
}
