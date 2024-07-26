using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Source: https://www.youtube.com/watch?v=N8whM1GjH4w

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip playerShoot;
    public AudioClip playerHit;
    public AudioClip playerDeath;
    public AudioClip pressPressurePlate;
    public AudioClip BulletImpact;

    public AudioClip skeletonAttack;
    public AudioClip skeletonHit;
    public AudioClip skeletonDeath;

    public AudioClip wizardAttack;
    public AudioClip wizardHit;
    public AudioClip wizardDeath;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
