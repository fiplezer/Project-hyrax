using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System.Threading.Tasks;

public class UITextChanges : MonoBehaviour
{
    [Header("TMP text")]
    public TMP_Text EnterWaterText;
    public TMP_Text TutorialText;
    public TMP_Text TObjective01;
    public TMP_Text TObjective02;
    public TMP_Text TObjective03;

    [Header("TMP Images")]
    public Image IObjective01;
    public Image IObjective02;
    public Image IObjective03;

    [Header("Second Image")]
    public Image FIObjective01;
    public Image FIObjective02;
    public Image FIObjective03;

    public bool TutorialObjectiveCompleted = false;
    public bool Uno = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void WaterEnterText()
    {
        EnterWaterText.gameObject.SetActive(true);
    }
    public void OnObjective01Complete()
    {
         IObjective01.enabled = false;
        
         FIObjective01.gameObject.SetActive(true);
    }
    public void OnObjective02Complete()
    {
        IObjective02.enabled = false;
        FIObjective02.gameObject.SetActive(true);
    }
    public void OnObjective03Complete()
    {
        IObjective03.enabled = false;
        FIObjective03.gameObject.SetActive(true);
    }
    
    public void OnTutorialComplete()
    {
        IObjective01.gameObject.SetActive(true);
        IObjective01.enabled = true;
        
        FIObjective01.enabled = false;
        FIObjective02.enabled = false;
        FIObjective03.enabled = false;
        TObjective02.enabled = false;
        TObjective03.enabled = false;

        
        TutorialText.SetText("Escape the maze, Tip : Look at the compass");
        TObjective01.SetText("- Turn all the sheep in the right direction");
    }

    public void OnMazeOneCompleted()
    {
        IObjective01.gameObject.SetActive(false);
        IObjective01.enabled = false;
        FIObjective01.gameObject.SetActive(true);
        FIObjective01.enabled = true;
        TutorialText.SetText("The second gate has opened");
    }

    public void OnMazeTwoEnter()
    {
        EnterWaterText.gameObject.SetActive(true);

        TutorialText.SetText("Don't fall off");
        FIObjective01.gameObject.SetActive(false);
        FIObjective01.enabled = false;
        IObjective01.enabled = true;
        IObjective01.gameObject.SetActive(true);

        TObjective01.SetText("Turn all four valves");
    }
}
