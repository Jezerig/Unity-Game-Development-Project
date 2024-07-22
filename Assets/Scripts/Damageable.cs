using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    Animator animator;
    private GameObject currentGameObject;
    public AIPath aiPath;
    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHealth
    {
        get { return _maxHealth; }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private int _health = 100;

    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if(_health <= 0 )
            {
                IsAlive = false;
                if (aiPath != null)
                {
                    aiPath.canSearch = false;
                    aiPath.canMove = false;
                }
                animator.SetFloat("Speed", 0);
                PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.enabled = false;
                }
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;
    [SerializeField]
    private bool isInvinsible = false;

    private float timeSinceHit = 0;
    private float invincibilityTime = 0.25f;

    public bool IsAlive 
    { 
        get { return _isAlive; } 
        set
        {
            _isAlive = value;
            animator.SetBool("isAlive", value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public bool Hit(int damage)
    {
        Debug.Log("Hit for " + damage);
        if (_isAlive && !isInvinsible)
        {
            Health -= damage;
            isInvinsible = true;
            animator.SetTrigger("GetHit");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        currentGameObject = animator.transform.gameObject;
        if (currentGameObject ==  GameObject.Find("Player")) 
        {
            if (GameData.PlayerHealth != 0)
            {
                Health = GameData.PlayerHealth;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isInvinsible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                isInvinsible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    } 
}
