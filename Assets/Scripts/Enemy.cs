using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UIElements;
using System.Runtime.InteropServices.WindowsRuntime;

public class Enemy : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public DetectionZone attackZone;
    public int damage = 21;
    public bool _isInRange = false;
    public bool isInRange
    {
        get { return _isInRange; }
        private set
        {
            _isInRange = value;
            animator.SetBool("isInRange", value);
            Attack();
        }
    }
    public AIPath aiPath;
    public Animator animator;
    public float walkSpeed = 5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    /*
    public float nextAttackTime = 0f;
    public float lastAttackTime = 0f;
    public float movementCooldown = 2f;
    public float attackRate = 0.25f;
   
    */

    void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D player in hitPlayers)
        {
            Damageable damageable = player.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.Hit(damage);
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isInRange)
        {
            aiPath.isStopped = true;
        } else
        {
            aiPath.isStopped = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        isInRange = attackZone.detectedColliders.Count > 0;
        
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetFloat("Speed", walkSpeed);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            animator.SetFloat("Speed", walkSpeed);
        }
        /*
        if (Time.time >= nextAttackTime)
        {
            if (isInRange)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                lastAttackTime = Time.time;
                aiPath.isStopped = true;
            }
        }
        if (Time.time >= lastAttackTime + 1)
        {
            aiPath.isStopped = false;
        }
        */
    }
}
