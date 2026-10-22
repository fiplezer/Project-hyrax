using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] public RawImage background;
    [SerializeField] private float waveSpeed, waveAmount;

    private float timer;
    void Update()
    {
        timer += Time.deltaTime;

        float waveX = MathF.Sin(timer * waveSpeed) * waveAmount;
        float waveY = MathF.Sin(timer * waveSpeed * 0.7f) * waveAmount;

        Vector2 position = background.uvRect.position + new Vector2(waveX, waveY);

        background.uvRect = new Rect(position, background.uvRect.size);
    }
}
