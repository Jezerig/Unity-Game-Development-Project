using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Camera cam;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    Vector2 movement;
    Vector2 mousePos;

    public void PlayerDeathSound()
    {
        audioManager.PlaySFX(audioManager.playerDeath);
    }

    public void PlayerAttackSound()
    {
        audioManager.PlaySFX(audioManager.playerShoot);
    }

    public void PlayerHitSound()
    {
        audioManager.PlaySFX(audioManager.playerHit);
    }

    public void LoadDeathScreen()
    {
        GameData.PlayerHealth = 100;
        SceneManager.LoadScene("DeathScreen");
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
            animator.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
