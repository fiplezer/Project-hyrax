using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class Maze1Finished : MonoBehaviour
{
    [Header("Components")]
    public GameObject Statue1;
    public GameObject Statue2;
    public GameObject Statue3;
    public GameObject Statue4;
    public GameObject Door1;
    public GameObject Door2;

    int statue1Value;
    int statue2Value;
    int statue3Value;
    int statue4Value;

    bool Once = true;

    public void Update()
    {
        Temp_Turning_script statue1 = Statue1.GetComponent<Temp_Turning_script>();
        Temp_Turning_script statue2 = Statue2.GetComponent<Temp_Turning_script>();
        Temp_Turning_script statue3 = Statue3.GetComponent<Temp_Turning_script>();
        Temp_Turning_script statue4 = Statue4.GetComponent<Temp_Turning_script>();

        statue1Value = statue1.value;
        statue2Value = statue2.value;
        statue3Value = statue3.value;
        statue4Value = statue4.value;

        if (statue1Value == 2f && statue2Value == 0f && statue3Value == 1f && statue4Value == 3f == Once == true)
        {
            Door1.GetComponent<DoorController>().ToggleDoor();
            Door2.GetComponent<DoorController>().ToggleDoor();
            Once = false;
        }
    }
}
