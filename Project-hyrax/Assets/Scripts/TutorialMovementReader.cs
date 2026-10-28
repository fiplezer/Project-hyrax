using Unity.AI.Navigation.LowLevel;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class TutorialMovementReader : MonoBehaviour
{
    public GameObject CharacterController;
    public Vector2 ReadMoveDirection;
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
        if (IsSprinting == (1))
        {
            Sprint = true;
        }
        if (Forward == true && Backward == true && Left == true && Right == true && Sprint == true && Once == true)
        {
            Door1.GetComponent<DoorController>().ToggleDoor();
            Door2.GetComponent<DoorController>().ToggleDoor();
            Once = false;
        } 
    }

    public void InteractWithButton()
    {
        Interacted = true;
    }
}
