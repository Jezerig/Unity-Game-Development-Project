using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBoss : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    private GameObject player;
    public Transform firePoint;
    private float nextAttackTime = 0;
    public float attackDelay = 2;

    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
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
