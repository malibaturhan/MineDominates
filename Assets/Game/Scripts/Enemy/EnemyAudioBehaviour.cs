using System;
using UnityEngine;

public class EnemyAudioBehaviour : MonoBehaviour
{
    [Header("***Clips***")]
    [SerializeField] private AudioClip deathCry;
    [SerializeField] private AudioClip walkSound;

    [Header("***Elements***")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Enemy enemy;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        enemy = GetComponent<Enemy>();
        enemy.OnStateChange += HandleEnemyState;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    private void HandleEnemyState(IEnemyState newState)
    {
        if (newState == typeof(DeadState)) 
        {
            Debug.LogWarning("ENEMY DEATH CRY PLAY");
            PlayDeathCry();
        }
    }

    public void PlayDeathCry()
    {
        audioSource.clip = deathCry;
        audioSource.Play();
    }

    private void OnDisable()
    {
        enemy.OnStateChange -= HandleEnemyState;
    }
}
