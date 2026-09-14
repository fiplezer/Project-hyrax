using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [Header("Components")]
    AudioSource audioSource;
    private Vector3 lastPosition;

    [Header("Audio Settings")]
    public AudioClip[] footstepSounds;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    void Update()
    {
        if(transform.position.x != lastPosition.x || transform.position.z != lastPosition.z)
        {
            Footstep();
        }

        lastPosition = transform.position;
        audioSource.volume = 0.2f;
    }

    public void Footstep()
    {
        if (!audioSource.isPlaying)
        {
            int random = Random.Range(0, footstepSounds.Length);
            var clip = footstepSounds[random];

            audioSource.PlayOneShot(clip);
        }
    }
}
