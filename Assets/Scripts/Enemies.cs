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


/*using System.Collections;
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

        }
        spawn = true;
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
}*/

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;

// public class Enemies : MonoBehaviour
// {
//     bool spawn = true;
//     public GameObject Prefab; // Enemy prefab
//     public GameObject bulletPrefab; // Reference to the bullet prefab
//     public Transform player; // Reference to the player's transform
//     public float moveSpeed = 2.0f; // Speed of the enemy
//     public float bulletSpeed = 50.0f; // Speed of the bullet
//     public bool isMoving = true; // Flag to control enemy movement

//     private ARRaycastManager arRaycastManager;

//     void Start()
//     {
//         arRaycastManager = GetComponent<ARRaycastManager>();
//     }

//     void Update()
//     {
//         if (spawn)
//         {
//             Invoke("Spawn", 3);
//             spawn = false;
//         }
//     }

//     void Spawn()
//     {
//         // Ensure you have a horizontal plane detected before spawning
//         if (arRaycastManager == null) return;

//         List<ARRaycastHit> hits = new List<ARRaycastHit>();
//         if (arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
//         {
//             // Get the hit point where the plane was detected
//             Pose hitPose = hits[0].pose;

//             float xPos = hitPose.position.x + Random.Range(-2.0f, 2.0f); // Offset to avoid clustering
//             float zPos = hitPose.position.z + Random.Range(-2.0f, 2.0f); // Offset to avoid clustering

//             Vector3 spawnPosition = new Vector3(xPos, hitPose.position.y, zPos);

//             // Spawn the enemy at the detected plane position
//             GameObject spawnedObject = Instantiate(Prefab, spawnPosition, Quaternion.identity);

//             // Optional: If you need to make the object move towards the player
//             if (Random.Range(1.0f, 2.0f) > 1.5f)
//             {
//                 StartCoroutine(MoveTowardsPlayer(spawnedObject));
//             }

//             // Start the shooting coroutine for the spawned enemy
//             StartCoroutine(ShootAtPlayer(spawnedObject));

//             spawn = true;
//         }
//     }

//     // Coroutine to move the enemy towards the player
//     IEnumerator MoveTowardsPlayer(GameObject obj)
//     {
//         while (obj != null && isMoving)
//         {
//             Vector3 direction = (player.position - obj.transform.position).normalized;
//             obj.transform.position += direction * moveSpeed * Time.deltaTime;
//             yield return null;
//         }
//     }

//     // Coroutine to shoot bullets at the player from the enemy
//     IEnumerator ShootAtPlayer(GameObject enemy)
//     {
//         while (enemy != null)
//         {
//             // Spawn the bullet at the enemy's position
//             GameObject bullet = Instantiate(bulletPrefab, enemy.transform.position, Quaternion.identity);

//             // Calculate the direction from the enemy to the player
//             Vector3 direction = (player.position - bullet.transform.position).normalized;

//             // Set the bullet's velocity towards the player
//             Rigidbody rb = bullet.GetComponent<Rigidbody>();
//             if (rb != null)
//             {
//                 rb.velocity = direction * bulletSpeed;
//             }

//             // Wait for 1 second before shooting the next bullet
//             yield return new WaitForSeconds(1f);
//         }
//     }

//     // Method to stop enemy movement
//     public void StopMovement()
//     {
//         isMoving = false;
//     }
// }
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
        }
        spawn = true;
    }

    // Coroutine to move the enemy towards the player using Rigidbody velocity
    IEnumerator MoveTowardsPlayer(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>(); // Get the Rigidbody component
        if (rb == null)
        {
            rb = obj.AddComponent<Rigidbody>(); // Add Rigidbody if not present
            rb.useGravity = false; // Disable gravity to keep movement controlled
        }

        while (obj != null)
        {
            float distance = Vector3.Distance(player.position, obj.transform.position);
            if (distance > 1.0f) // Change this value based on when you want the enemy to stop
            {
                // Calculate direction towards the player and set velocity
                Vector3 direction = (player.position - obj.transform.position).normalized;
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                // Stop the enemy's movement when close enough
                rb.velocity = Vector3.zero;
            }

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

    // Method to stop enemy movement, now handled per enemy using Rigidbody velocity
    public void StopMovement(GameObject enemy)
    {
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
