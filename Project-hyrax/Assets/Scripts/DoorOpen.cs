using System.Collections;
using System.Threading;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IInteractable
{
    [Header("Components")]
    public GameObject Statue1;
    public GameObject Statue2;
    public GameObject Statue3;
    AudioSource audioSource;

    [Header("Audio")]
    public AudioClip DoorLockSound;

    int statue1Value;
    int statue2Value;
    int statue3Value;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Interact()
    {
        Temp_Turning_script statue1 = Statue1.GetComponent<Temp_Turning_script>();
        Temp_Turning_script statue2 = Statue2.GetComponent<Temp_Turning_script>();
        Temp_Turning_script statue3 = Statue3.GetComponent<Temp_Turning_script>();

        statue1Value = statue1.value;
        statue2Value = statue2.value;
        statue3Value = statue3.value;
    }
    void Update()
    {
        if (statue1Value == 1f && statue2Value == 2f && statue3Value == 3f && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(DoorLockSound);
            StartCoroutine(waitOneSeconds());
        }

        return;
    }

    IEnumerator waitOneSeconds()
    {
        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);
    }
}
