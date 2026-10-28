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
    public GameObject Moon;
    public ParticleSystem Fireflies;
    public ParticleSystem Leaves;

    [Header("Audio")]
    [SerializeField] private MusicFade MusicFade;
    public AudioClip FlashlightClick;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        MoodCollider = Mood.GetComponent<Collider>();
        DarkCollider = this.GetComponent<Collider>();
        Fireflies.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        Fireflies.Stop();
        Leaves.Play();
        RenderSettings.ambientIntensity = 0.0f;
        Flashlight.SetActive(true);
        audioSource.PlayOneShot(FlashlightClick);
        WaterObject.GetComponent<WaterRise>().Deactivate();
        Moon.gameObject.SetActive(false);
        MusicFade.ToggleMusic();
        MoodCollider.enabled = true; //moet mogelijk onderaan is dingen niet switchen - Zoe
        DarkCollider.enabled = false;
    }
}
