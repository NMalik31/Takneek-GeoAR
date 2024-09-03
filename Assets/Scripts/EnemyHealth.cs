using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 30f;       // Initial health of the prefab
    public float collisionDamage = 10f; // Damage taken upon collision

    void OnCollisionEnter(Collision collision)
    {
        // Decrease health by collision damage
        health -= collisionDamage;

        // Check if health is 0 or below
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
