using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void WaterEnterText()
    {
        EnterWaterText.gameObject.SetActive(true);
    }
    public void OnObjective01Complete()
    {
        IObjective01.enabled = false;
        if (!TutorialObjectiveCompleted)
        {
            FIObjective01.gameObject.SetActive(true);
        }
        else
        {
            FIObjective01.gameObject.SetActive(false);
            IObjective01.enabled = true;
        }
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
        TutorialObjectiveCompleted = true;
        if (TutorialObjectiveCompleted)
        {
            FIObjective01.gameObject.SetActive(false);
            FIObjective02.gameObject.SetActive(false);
            FIObjective03.gameObject.SetActive(false);
            TObjective02.gameObject.SetActive(false);
            TObjective03.gameObject.SetActive(false);
            TutorialText.SetText("Escape the maze");
            TObjective01.SetText("- Turn the four pillars");
            IObjective01.gameObject.SetActive(true);
            IObjective01.enabled = true;
        }
    }

    public void OnMazeOneCompleted()
    {
        FIObjective01.gameObject.SetActive(true);
        FIObjective01.enabled = true;
        IObjective01.gameObject.SetActive(false);
        TutorialText.SetText("The second gate has opened");
    }
}
