using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public bool playerAlive = true;
    public Transform attackPoint;
    public float attackRange = 2f;
    public float nextAttackTime = 0f;
    public float attackDelay = 1f;
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
        }
    }
    public AIPath aiPath;
    public Animator animator;
    public float walkSpeed = 5f;

    AudioManager audioManager;

    // Source for combat: https://www.youtube.com/watch?v=sPiVz1k-fEs, https://www.youtube.com/watch?v=hl9q6IWiVqA
    // Source for AI movement: https://www.youtube.com/watch?v=jvtFUfJ6CP8

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
    }

    // Sounds effects
    public void SkeletonDeathSound()
    {
        audioManager.PlaySFX(audioManager.skeletonDeath);
    }

    public void SkeletonAttackSound()
    {
        audioManager.PlaySFX(audioManager.skeletonAttack);
    }

    public void SkeletonHitSound()
    {
        audioManager.PlaySFX(audioManager.skeletonHit);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        // Checks all the collisions (if multiple players)
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D player in hitPlayers)
        {
            Damageable damageable = player.GetComponent<Damageable>();
            if (damageable != null)
            {
                if (!damageable.Hit(damage))
                {
                    playerAlive = false;
                }
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
    private void FixedUpdate()
    {
        if (aiPath != null)
        {
            if (_isInRange)
            {
                aiPath.isStopped = true;
            }
            else
            {
                aiPath.isStopped = false;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (playerAlive)
        {
            // attack speed
            if (Time.time >= nextAttackTime)
            {
                isInRange = attackZone.detectedColliders.Count > 0;
                Damageable character = gameObject.GetComponent<Damageable>();
                if (isInRange && character.IsAlive)
                {
                    Attack();
                    nextAttackTime = Time.time + attackDelay;
                }
            }
            else
            {
                isInRange = false;
            }
        } else
        {
            if (aiPath != null)
            {
                // Stops AI follow
                aiPath.canSearch = false;
                aiPath.canMove = false;
            }
            animator.SetBool("playerAlive", false);
        }
        
        // Turns the enemy based on the players position
        if(aiPath != null)
        {
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
        }
    }
}
