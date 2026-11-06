using System.Collections;
using Unity.AI.Navigation.LowLevel;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class TutorialMovementReader : MonoBehaviour
{
    public GameObject CharacterController;
    public Vector2 ReadMoveDirection;
    public UITextChanges UITextChanges;
    public GameObject Door1;
    public GameObject Door2;
    public float IsSprinting;
    private bool Forward = false;
    private bool Backward = false;
    private bool Left = false;
    private bool Right = false;
    private bool Sprint = false;
    public bool Interacted = false;
    private bool Once = true;
    private bool Once1 = true;
    private bool Once2 = true;

    private void Start()
    {
        StartCoroutine(ActivateMovement());
    }

    void Update()
    {
        ReadMoveDirection = CharacterController.GetComponent<Player_Controller>().moveVector;
        IsSprinting = CharacterController.GetComponent<Player_Controller>().sprintCheck;

        if (ReadMoveDirection == new Vector2(0, 1))
        {
            Forward = true;
        }
        if (ReadMoveDirection == new Vector2(0, -1))
        {
            Backward = true;
        }
        if (ReadMoveDirection == new Vector2(-1, 0))
        {
            Left = true;
        }
        if (ReadMoveDirection == new Vector2(1, 0))
        {
            Right = true;
        }
        if (Forward == true & Backward == true & Left == true & Right == true && Once1)
        {
            UITextChanges.OnObjective01Complete();
            Once1 = false;
        }
        if (IsSprinting == (1) && Once2)
        {
            Sprint = true;
            UITextChanges.OnObjective02Complete();
            Once2 = false;
        }
        if (Forward == true && Backward == true && Left == true && Right == true && Sprint == true && Interacted == true && Once == true)
        {
            Door1.GetComponent<DoorController>().ToggleDoor();
            Door2.GetComponent<DoorController>().ToggleDoor();
            UITextChanges.OnTutorialComplete();
            Once = false;
        } 
    }

    public void InteractWithButton()
    {
        Interacted = true;
        UITextChanges.OnObjective03Complete();
    }

    IEnumerator ActivateMovement()
    {
        yield return new WaitForSeconds(3);

        CharacterController.GetComponent<Player_Controller>().enabled = true;
    }
}
