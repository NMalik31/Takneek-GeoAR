using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Reference to the bullet spawn point
    public float bulletSpeed = 100f; // Speed of the bullet

    // Method to shoot the bullet
    public void Shoot()
    {
        // Instantiate the bullet at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        
        // Get the Rigidbody component of the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        // Add force to the bullet to make it move
        rb.velocity = bulletSpawnPoint.TransformDirection(Vector3.forward) * bulletSpeed;
        // rb.velocity=new Vector3(0,0,20);
    }
}
