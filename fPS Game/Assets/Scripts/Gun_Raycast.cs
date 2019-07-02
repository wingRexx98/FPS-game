
using UnityEngine;

public class Gun_Raycast : MonoBehaviour
{
    public float damage;
    public float distance;
    public float impactForce;
    public float fireRate;

    public Camera fpsCam;

    public ParticleSystem shot;

    public GameObject impactEffect;

    private float nextToFire;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextToFire)
        {
            nextToFire = Time.time + 1f/ fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        shot.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, distance))
        {
            Debug.Log(hitInfo.transform.name);

            target tar = hitInfo.transform.GetComponent<target>();
            if(tar != null)
            {
                tar.TakeDamage(damage);
            }

            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactGO, 2f);
        }
    }
}
