using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStop : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float stopDistance = 1.0f; // Distance at which the enemy stops moving

    void Update()
    {
        // Find all enemies with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            // Calculate the distance between the player and the enemy
            float distance = Vector3.Distance(player.position, enemy.transform.position);

            // Check if the distance is less than the stopDistance
            if (distance < stopDistance)
            {
                // Stop the enemy's movement
                StopEnemyMovement(enemy);
            }
        }
    }

    // Method to stop the enemy's movement by setting its velocity to zero
    void StopEnemyMovement(GameObject enemy)
    {
        // Get the Rigidbody component from the enemy gameObject
        Rigidbody rb = enemy.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = Vector3.zero; // Set the velocity to zero
            rb.angularVelocity = Vector3.zero; // Optionally, stop any angular velocity
        }
    }
}
