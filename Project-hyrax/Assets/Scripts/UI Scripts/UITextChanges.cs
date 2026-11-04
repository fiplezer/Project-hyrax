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

    [Header("TMP iamges")]
    public RawImage IObjective01;
    public RawImage IObjective02;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void WaterEnterText()
    {
        EnterWaterText.gameObject.SetActive(true);
    }

   
}
