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
    private void Awake()
    {
        MoodCollider = Mood.GetComponent<Collider>();
        CornCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        MoodCollider.enabled = true;
        CornCollider.enabled = false;
        WaterObject.GetComponent<WaterRise>().Deactivate();
        Backgroundmusic2.gameObject.SetActive(true);
        Backgroundmusic3.gameObject.SetActive(false);
    }
}
