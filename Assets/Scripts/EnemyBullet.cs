using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    public Animator animator;
    private Rigidbody2D rb;
    public int damage = 49;
    public float fireForce = 20f;
    public float bulletLiveTime = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null && damageable.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            animator.SetTrigger("Explode");
            damageable.Hit(damage);
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Explode");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * fireForce;

        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        Destroy(gameObject, bulletLiveTime);
    }
}
