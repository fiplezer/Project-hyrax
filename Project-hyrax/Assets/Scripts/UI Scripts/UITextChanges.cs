using UnityEngine;
using TMPro;

public class UITextChanges : MonoBehaviour
{
    public TMP_Text EnterWaterText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void WaterEnterText()
    {
        EnterWaterText.gameObject.SetActive(true);
    }
}
