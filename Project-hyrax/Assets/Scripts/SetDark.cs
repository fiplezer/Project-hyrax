using UnityEngine;

public class SetDark : MonoBehaviour
{
    [Header("Components")]
    public GameObject Flashlight;
    public GameObject Mood;
    AudioSource audioSource;
    private Collider MoodCollider;
    private Collider DarkCollider;
    public GameObject WaterObject;

    [Header("Audio")]
    public AudioClip FlashlightClick;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        MoodCollider = Mood.GetComponent<Collider>();
        DarkCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.ambientIntensity = 0.0f;
        Flashlight.SetActive(true);
        MoodCollider.enabled = true;
        DarkCollider.enabled = false;
        audioSource.PlayOneShot(FlashlightClick);
        WaterObject.GetComponent<WaterRise>().Deactivate();
    }
}
