using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float fireRate;

    public GameObject bulletPrefab;

    public Transform firePoint;

    private float nextToFire;

    public void Shoot()
    {
        if (Time.time >= nextToFire)
        {
            nextToFire = Time.time + 1f / fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        
    }
}
