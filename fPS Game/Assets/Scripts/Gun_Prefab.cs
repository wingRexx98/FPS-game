using UnityEngine;

public class Gun_Prefab : MonoBehaviour
{
    public float fireRate;

    public GameObject bulletPrefab;

    public Transform firePoint;

    public ParticleSystem shot;

    private float nextToFire;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextToFire)
        {
            nextToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        shot.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
