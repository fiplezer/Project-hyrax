using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [Header("Components")]

    AudioSource audioSource;

    [Header("Audio Settings")]
    public AudioClip[] footstepSounds;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Footstep();
        }

            
    }

    public void Footstep()
    {
        int random = Random.Range(0, footstepSounds.Length);
        var clip = footstepSounds[random];
        audioSource.PlayOneShot(clip);
    }
}
