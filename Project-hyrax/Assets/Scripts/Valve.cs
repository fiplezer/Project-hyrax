using UnityEngine;
using System.Threading;
using System.Collections;

public class Valve : MonoBehaviour, IInteractable
{
    public float rotationSpeed = 180f;
    private Quaternion targetRotation;
    private bool Turnable = true;
    public GameObject WaterObject;
    public bool Turned = false;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    public void Interact()
    {
        if (Turnable == true)
        {
            targetRotation *= Quaternion.Euler(0, 90, 0);
            StartCoroutine(waitThreeSeconds());
            Turnable = false;
            WaterObject.GetComponent<WaterRise>().ActivateLower();
            Turned = true;
        }
    }

    public void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(3);

        enabled = false;
    }
}
