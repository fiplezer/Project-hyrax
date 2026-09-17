using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float WalkSpeed = 5.5f;
    [SerializeField] private float RunSpeed = 9f;
    [SerializeField] private float gravity = 20f;

    [SerializeField] private float stamina = 5f;
    [SerializeField] private float maxStamina = 5f;
    [SerializeField] private float chargeRate = 1f;

    [SerializeField] private float LookSensitivity = 0.2f;
    [SerializeField] private float LookAngleLimit = 90f;

    private Camera mainCamera;
    private CharacterController characterController;

    private InputAction moveInput;
    private InputAction runInput;

    private float currentMoveSpeed = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float lookAngle = 0.0f;

    private Coroutine recharge;
    private bool recharging = false;

    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();

        moveInput = InputSystem.actions.FindAction("Move");
        runInput = InputSystem.actions.FindAction("Sprint");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentMoveSpeed = WalkSpeed;
    }

    void Update()
    {
        Vector2 moveVector = moveInput.ReadValue<Vector2>();

        float sprintCheck;
        if (moveVector.x != 0 || moveVector.y != 0)
        {
            sprintCheck = runInput.ReadValue<float>();
        }
        else
        {
            sprintCheck = 0;
        }

        Vector2 mouseDelta = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());

        Sprint(sprintCheck, moveVector);
        HandleMovement(moveVector);
        HandleLooking(mouseDelta);
    }

    private void HandleMovement(Vector2 moveVector)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float oldY = moveDirection.y;

        Vector2 newSpeed = new Vector2(moveVector.y * currentMoveSpeed, moveVector.x * currentMoveSpeed);

        moveDirection = (forward * newSpeed.x) + (right * newSpeed.y);
        moveDirection.y = oldY;

        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;
        else if (characterController.isGrounded && moveDirection.y != 0)
            moveDirection.y = 0f;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void HandleLooking(Vector2 mouseDelta)
    {
        lookAngle += -mouseDelta.y * LookSensitivity;
        lookAngle = Mathf.Clamp(lookAngle, -LookAngleLimit, LookAngleLimit);

        mainCamera.transform.localRotation = Quaternion.Euler(lookAngle, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x * LookSensitivity, 0);
    }


    private void Sprint(float sprintCheck, Vector2 moveVector)
    {
        if (sprintCheck == 1 && stamina > 0)
        {
            if (recharge != null)
            {
                StopCoroutine(recharge);
                recharge = null;
            }

            recharging = false;
            currentMoveSpeed = RunSpeed;
            stamina -= Time.deltaTime;
        }
        
        if (sprintCheck == 0 || stamina < 0)
        {
            currentMoveSpeed = WalkSpeed;

            if (!recharging)
            {
                recharging = true;
                recharge = StartCoroutine(RechargeStamina());
            }
        }
    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while (stamina < maxStamina)
        {
            stamina += chargeRate * Time.deltaTime;

            if (stamina >= maxStamina)
            {
                stamina = maxStamina;
                recharging = false;
                recharge = null;
                yield break;
            }

            yield return null;
        }

        recharging = false;
        recharge = null;
    }

}
