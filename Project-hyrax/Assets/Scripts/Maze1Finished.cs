using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class Maze1Finished : MonoBehaviour
{
    [Header("Components")]
    public GameObject Sheep1;
    public GameObject Sheep2;
    public GameObject Sheep3;
    public GameObject Sheep4;
    public GameObject Door1;
    public GameObject Door2;
    public UITextChanges UITextChanges;

    int statue1Value;
    int statue2Value;
    int statue3Value;
    int statue4Value;

    bool Once = true;

    public void Update()
    {
        Maze1_Turning_script sheep1 = Sheep1.GetComponent<Maze1_Turning_script>();
        Maze1_Turning_script sheep2 = Sheep2.GetComponent<Maze1_Turning_script>();
        Maze1_Turning_script sheep3 = Sheep3.GetComponent<Maze1_Turning_script>();
        Maze1_Turning_script sheep4 = Sheep4.GetComponent<Maze1_Turning_script>();

        statue1Value = sheep1.value;
        statue2Value = sheep2.value;
        statue3Value = sheep3.value;
        statue4Value = sheep4.value;

        if (statue1Value == 2f && statue2Value == 0f && statue3Value == 1f && statue4Value == 3f && Once == true)
        {
            Door1.GetComponent<DoorController>().ToggleDoor();
            Door2.GetComponent<DoorController>().ToggleDoor();
            Once = false;
            UITextChanges.OnMazeOneCompleted();
        }
    }
}
