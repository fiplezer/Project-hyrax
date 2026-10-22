using UnityEngine;

public class SetCorn : MonoBehaviour
{
    [Header("Components")]
    public GameObject Mood;
    private Collider MoodCollider;
    private Collider CornCollider;
    public GameObject WaterObject;
    public GameObject Moon;
    public GameObject Backgroundmusic2;
    public GameObject Backgroundmusic3;
    public ParticleSystem Fireflies;
    public ParticleSystem Leaves;

    [Header("Audio")]
    [SerializeField] private MusicFade MusicFade;
    private void Awake()
    {
        MoodCollider = Mood.GetComponent<Collider>();
        CornCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Fireflies.Play();
        Leaves.Stop();
        WaterObject.GetComponent<WaterRise>().Deactivate();
        Backgroundmusic2.gameObject.SetActive(true);
        Backgroundmusic3.gameObject.SetActive(false);
        MusicFade.ToggleMusic();
        MoodCollider.enabled = true;
        CornCollider.enabled = false;
    }
}
