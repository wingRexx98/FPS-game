using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float impactForce;

    public GameObject impactEffect;

    public float speed = 10f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        target tar = other.GetComponent<target>();
        if (tar != null)
        {
            tar.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
