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

    private CharacterController characterController;
    private InputAction interactInput;


    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        InteractorSource = mainCamera.transform;
        characterController = GetComponent<CharacterController>();
        interactInput = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (interactInput.IsPressed())
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
