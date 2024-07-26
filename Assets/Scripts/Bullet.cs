using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Source https://www.youtube.com/watch?v=LqrAbEaDQzc

    public float bulletLiveTime = 5f; // Time it takes before bullet automatically gets destroyed https://discussions.unity.com/t/destroying-projectile-prefabs-after-time/187507
    public int damage = 34;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void BulletImpactSound()
    {
        audioManager.PlaySFX(audioManager.BulletImpact);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Does damage to a damageable target
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.Hit(damage);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletImpactSound();
        Destroy(gameObject);
    }

    private void Start()
    {
        Destroy(gameObject, bulletLiveTime);
    }
}
