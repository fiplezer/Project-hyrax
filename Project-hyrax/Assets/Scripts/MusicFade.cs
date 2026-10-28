using System.Collections;
using UnityEngine;

public class MusicFade : MonoBehaviour
{
    public float FadeDuration = 2;

    [SerializeField] private float MaxVolume = 1.0f;
    [SerializeField] private AudioSource[] AudioSources;

    private int LastAudioSourceIndex;

    public void ToggleMusic()
    {
        StopAllCoroutines();
        StartCoroutine(routine: FadeSources());
    }

    private IEnumerator FadeSources()
    {
        float time = 0;
        int newTargetIndex = LastAudioSourceIndex == 0 ? 1 : 0;

        AudioSource lastSource = AudioSources[LastAudioSourceIndex];
        AudioSource newSource = AudioSources[newTargetIndex];

        newSource.Play();

        float lastInitialVolume = lastSource.volume;
        float newInitialVolume = newSource.volume;

        while (time < 1)
        {
            lastSource.volume = Mathf.Lerp(lastInitialVolume, 0, t: time);
            newSource.volume = Mathf.Lerp(newInitialVolume, MaxVolume, t: time);
            time += Time.deltaTime * (1 / FadeDuration);
            yield return null;
        }

        lastSource.volume = 0;
        newSource.volume = MaxVolume;
        lastSource.Stop();

        LastAudioSourceIndex = newTargetIndex;
    }
}
