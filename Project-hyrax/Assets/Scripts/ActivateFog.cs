using UnityEngine;

public class ActivateFog : MonoBehaviour
{
    public float fogIncreaseSpeed = 0.01f;
    public float targetFogDensity = 1f;

    private bool increasingFog = false;

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0f;
        increasingFog = true;
    }

    private void Update()
    {
        if (increasingFog == true)
        {
            RenderSettings.fogDensity = Mathf.MoveTowards(
                RenderSettings.fogDensity,
                targetFogDensity,
                fogIncreaseSpeed * Time.deltaTime
            );

            if (RenderSettings.fogDensity >= targetFogDensity)
            {
                increasingFog = false;
            }
        }
    }
}