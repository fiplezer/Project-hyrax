using UnityEngine;
using System.Threading;

public class Valve : MonoBehaviour, IInteractable
{
    public float rotationSpeed = 180f;
    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    public void Interact()
    {
        targetRotation *= Quaternion.Euler(0, 90, 0);

        Debug.Log("test");
    }

    public void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
