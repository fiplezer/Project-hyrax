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
    public GameObject Player;
    private GameObject WeepingAngel;

    [Header("Audio")]
    [SerializeField] private MusicFade MusicFade;
    private void Awake()
    {
        MoodCollider = Mood.GetComponent<Collider>();
        CornCollider = this.GetComponent<Collider>();
        WeepingAngel = GameObject.FindGameObjectWithTag("Weeping");
    }

    private void OnTriggerEnter(Collider other)
    {
        Fireflies.gameObject.SetActive(false);
        Fireflies.Stop();
        Leaves.Play();
        WaterObject.GetComponent<WaterRise>().Deactivate();
        Backgroundmusic2.gameObject.SetActive(true);
        Backgroundmusic3.gameObject.SetActive(false);
        MusicFade.ToggleMusic();
        MoodCollider.enabled = true;
        CornCollider.enabled = false;
        Player.GetComponent<FootstepAudio>().enabled = true;
        Player.GetComponent<FootstepAudioStone>().enabled = false;

        if (WeepingAngel.activeInHierarchy == false)
        {
            WeepingAngel.SetActive(true);
        }
    }
}
