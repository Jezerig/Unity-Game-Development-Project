using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLiveTime = 5f;
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
