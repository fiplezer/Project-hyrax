using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    private Camera mainCamera;
    private Transform InteractorSource;
    [SerializeField] private float InteractRange = 2f;
    public float CooldownTime = 0.5f;

    private CharacterController characterController;
    private InputAction interactInput;

    private IEnumerator coroutine;
    private bool coolDown;


    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        InteractorSource = mainCamera.transform;
        characterController = GetComponent<CharacterController>();
        interactInput = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (interactInput.IsPressed() && !coolDown)
        {
            coolDown = true;
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
            coroutine = Cooldown(CooldownTime);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator Cooldown(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        coolDown = false;
    }
}
