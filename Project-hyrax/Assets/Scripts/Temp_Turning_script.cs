using System.Collections;
using UnityEngine;

public class Temp_Turning_script : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    public int value = 0;
    public float turnDuration = 0.5f;
    bool isTurning = false;

    public GameObject SatuePole;


    public void Interact()
    {
        if (!isTurning)
            StartCoroutine(SmoothTurn());
    }

    IEnumerator SmoothTurn()
    {
        isTurning = true;

        Quaternion start = transform.rotation;
        Quaternion end = start * Quaternion.Euler(0, -90, 0);

        float t = 0;
        while (t < turnDuration)
        {
            transform.rotation = Quaternion.Slerp(start, end, t / turnDuration);
            t += Time.deltaTime;
            yield return null;
        }

        transform.rotation = end;
        value = (value + 1) % 4;
        isTurning = false;
    }
}

