using UnityEngine;

public class ActivateFog : MonoBehaviour
{
    public float fogIncreaseSpeed = 0.01f;
    public float targetFogDensity = 1f;

    private bool increasingFog = false;
    private bool decreasingFog = false;

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fog = true;
        increasingFog = true;
        decreasingFog = false;
    }

    private void OnTriggerExit(Collider other)
    {
        decreasingFog = true;
        increasingFog = false;
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

        if (decreasingFog == true)
        {
            RenderSettings.fogDensity = Mathf.MoveTowards(
                RenderSettings.fogDensity,
                0f,
                fogIncreaseSpeed * Time.deltaTime
            );

            if (RenderSettings.fogDensity <= 0f)
            {
                RenderSettings.fogDensity = 0f;
                decreasingFog = false;
                RenderSettings.fog = false;
            }
        }
    }
}