using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Source: https://www.youtube.com/watch?v=LqrAbEaDQzc

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    // Fires a bullet from the player firepoint and set fireforce
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
