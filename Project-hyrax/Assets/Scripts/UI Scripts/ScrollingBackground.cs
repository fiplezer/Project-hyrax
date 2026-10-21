using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] public RawImage background;
    [SerializeField] private float waveSpeed, waveAmount;

    private float timer;

    private void Start()
    {
  
    }
    void Update()
    {
        timer += Time.deltaTime;
        // background.uvRect = new Rect(background.uvRect.position + new Vector2(scrollX, scrollY) * Time.deltaTime, background.uvRect.size);//
        //float x = background.uvRect.x + scrollX * Time.deltaTime;
        //float y = background.uvRect.y + scrollY * Time.deltaTime;

        float waveX = MathF.Sin(timer * waveSpeed) * waveAmount;
        float waveY = MathF.Sin(timer * waveSpeed * 0.7f) * waveAmount;

        Vector2 position = background.uvRect.position + new Vector2(waveX, waveY);

        background.uvRect = new Rect(position, background.uvRect.size);
    }
}
