using UnityEngine;
using UnityEngine.Audio;

public class SetMood : MonoBehaviour
{
    [Header("Components")]
    public GameObject Flashlight;
    public GameObject Dark;
    AudioSource audioSource;
    private Collider MoodCollider;
    private Collider DarkCollider;
    public GameObject WaterObject;
    public GameObject Moon;
    public ParticleSystem Fireflies;
    public ParticleSystem Leaves;

    [Header("Audio")]
    [SerializeField] private MusicFade MusicFade;
    public AudioClip FlashlightClick;

    [Header("TextAnimation")]
    [SerializeField] private UITextChanges UiTextChanges;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DarkCollider = Dark.GetComponent<Collider>();
        MoodCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Fireflies.Play();
        Leaves.Stop();
        //UiTextChanges.EnterWaterText(); Ben ik nog mee bezig - Zoe
        RenderSettings.ambientIntensity = 0.5f;
        Flashlight.SetActive(false);
        audioSource.PlayOneShot(FlashlightClick);
        WaterObject.GetComponent<WaterRise>().Activate();
        Moon.gameObject.SetActive(true);
        MusicFade.ToggleMusic();
        DarkCollider.enabled = true;
        MoodCollider.enabled = false;
    }
}
