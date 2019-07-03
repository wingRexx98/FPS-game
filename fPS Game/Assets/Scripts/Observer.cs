using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;// in stead gameobject, transform is use to determine whether or not the player is in view or whther the gargoyle can see the player
    bool isInRange;
    public float fireRate = 15f;
    public EnemyShoot shoot;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            shoot.Shoot();
        }
    }
}
