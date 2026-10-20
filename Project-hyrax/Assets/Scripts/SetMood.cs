using UnityEngine;

public class SetMood : MonoBehaviour
{
    [Header("Components")]
    public GameObject Flashlight;
    public GameObject Dark;
    AudioSource audioSource;
    private Collider MoodCollider;
    private Collider DarkCollider;

    [Header("Audio")]
    public AudioClip FlashlightClick;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DarkCollider = Dark.GetComponent<Collider>();
        MoodCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.ambientIntensity = 0.5f;
        Flashlight.SetActive(false);
        DarkCollider.enabled = true;
        MoodCollider.enabled = false;
        audioSource.PlayOneShot(FlashlightClick);
    }
}
