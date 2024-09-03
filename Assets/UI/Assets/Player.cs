/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
	bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(1);
		}
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemies.Length;
		if(spawn)
		{
			Invoke("TakeDamage")
		}
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    bool spawn = true;
	public GameObject GameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemies.Length;
		foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= 10f)
            {
                // Reduce health and stop the enemy
                if (spawn)
				{
					// Use a lambda function to call TakeDamage with the enemyCount parameter
					Invoke(() => TakeDamage(5), 1f); // Delay of 1 second for example
					spawn = false; // Set spawn to false to avoid repeated calls
				}
                //enemy.GetComponent<Enemies>().StopMovement(); // Stop the enemy's movement
            }
        }
        if (spawn)
        {
            // Use a lambda function to call TakeDamage with the enemyCount parameter
            Invoke(() => TakeDamage(enemyCount), 1f); // Delay of 1 second for example
            spawn = false; // Set spawn to false to avoid repeated calls
        }
    }

    // Method to reduce player health based on damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
		spawn=true;
    }

    // Overload of Invoke to support delayed execution with parameters using lambda
    void Invoke(System.Action action, float delay)
    {
        StartCoroutine(InvokeCoroutine(action, delay));
    }

    IEnumerator InvokeCoroutine(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
