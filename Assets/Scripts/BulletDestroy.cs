using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float maxZValue = 15f; // The z value threshold after which the bullet is destroyed

    void Update()
    {
        // Check if the bullet's z value is greater than the maxZValue
        if (transform.position.z > maxZValue)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet upon collision
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the bullet upon collision with an obstacle
            Destroy(gameObject);
        }
    }
}