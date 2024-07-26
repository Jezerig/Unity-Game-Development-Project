using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WizardBoss : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    private GameObject player;
    public Transform firePoint;
    private float nextAttackTime = 0;
    public float attackDelay = 2;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Boss shooting
    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    // Destroy boss GameObject (when killed)
    public void Kill()
    {
        Destroy(gameObject);
    }

    // Different sounds the boss makes
    public void WizardAttackSound()
    {
        audioManager.PlaySFX(audioManager.wizardAttack);
    }
    public void WizardDeathSound()
    {
        audioManager.PlaySFX(audioManager.wizardDeath);
    }
    public void WizardHitSound()
    {
        audioManager.PlaySFX(audioManager.wizardHit);
    }

    // Load Credits scene (on kill)
    public void loadCredits()
    {
        GameData.PlayerHealth = 100;
        SceneManager.LoadSceneAsync("Credits");
    }

    // Destroys all the enemies (when the boss is killed)
    public void DestroyEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Damageable player = GameObject.Find("Player").GetComponent<Damageable>();
        if (player != null && player.IsAlive && animator.transform.gameObject.GetComponent<Damageable>().IsAlive)
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + attackDelay;
            }
        }
    }    
}
