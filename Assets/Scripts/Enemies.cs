/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    bool spawn = true;
    public GameObject Prefab;
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 2.0f;
    public bool isMoving = true;
    void Update()
    {
        if (spawn)
        {
            Invoke("Spawn", 3);
            spawn = false;
        }
    }

    void Spawn()
    {
        float xPos = Random.Range(-8.0f, 8.0f);
        float zPos = Random.Range(3.0f, 10.0f);
        float temp = Random.Range(1.0f, 2.0f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemies.Length;
        if (enemyCount <= 10)
        {
            Vector3 spawnPosition = new Vector3(xPos, 0, zPos);
            GameObject spawnedObject = Instantiate(Prefab, spawnPosition, Quaternion.identity);

            if (temp > 1.5f)
            {
                // Make the object move towards the player
                StartCoroutine(MoveTowardsPlayer(spawnedObject));
            }

            spawn = true;
        }
        
    }

    IEnumerator MoveTowardsPlayer(GameObject obj)
    {
        while (obj != null && isMoving)
        {
            Vector3 direction = (player.position - obj.transform.position).normalized;
            obj.transform.position += direction * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }

    public void StopMovement()
    {
        isMoving = false;
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    bool spawn = true;
    public GameObject Prefab; // Enemy prefab
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 2.0f; // Speed of the enemy
    public float bulletSpeed = 50.0f; // Speed of the bullet
    public bool isMoving = true; // Flag to control enemy movement

    void Update()
    {
        if (spawn)
        {
            Invoke("Spawn", 3);
            spawn = false;
        }
    }

    void Spawn()
    {
        float xPos = Random.Range(-8.0f, 8.0f);
        float zPos = Random.Range(3.0f, 10.0f);
        float temp = Random.Range(1.0f, 2.0f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemies.Length;
        if (enemyCount <= 10)
        {
            Vector3 spawnPosition = new Vector3(xPos, 0, zPos);
            GameObject spawnedObject = Instantiate(Prefab, spawnPosition, Quaternion.identity);

            if (temp > 1.5f)
            {
                // Make the object move towards the player
                StartCoroutine(MoveTowardsPlayer(spawnedObject));
            }

            // Start the shooting coroutine for the spawned enemy
            StartCoroutine(ShootAtPlayer(spawnedObject));

            spawn = true;
        }
    }

    // Coroutine to move the enemy towards the player
    IEnumerator MoveTowardsPlayer(GameObject obj)
    {
        while (obj != null && isMoving)
        {
            Vector3 direction = (player.position - obj.transform.position).normalized;
            obj.transform.position += direction * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }

    // Coroutine to shoot bullets at the player from the enemy
    IEnumerator ShootAtPlayer(GameObject enemy)
    {
        while (enemy != null)
        {
            // Spawn the bullet at the enemy's position
            GameObject bullet = Instantiate(bulletPrefab, enemy.transform.position, Quaternion.identity);

            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.position - bullet.transform.position).normalized;

            // Set the bullet's velocity towards the player
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }

            // Wait for 1 second before shooting the next bullet
            yield return new WaitForSeconds(1f);
        }
    }

    // Method to stop enemy movement
    public void StopMovement()
    {
        isMoving = false;
    }
}
