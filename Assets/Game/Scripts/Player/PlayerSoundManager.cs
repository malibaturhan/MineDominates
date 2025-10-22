using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{

    [Header("***Clips***")]
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip deathClip;

    [Header("***Elements***")]
    [SerializeField] private AudioSource playerAudioSource;

    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayHurtAudio()
    {
        playerAudioSource.clip = hurtClip;
        playerAudioSource.Play();
    }

    public void PlayDeathAudio() 
    {
        playerAudioSource.clip = deathClip;
        playerAudioSource.Play();
    }
}
