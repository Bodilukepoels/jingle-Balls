using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // A reference to the enemy prefab
    public GameObject enemyPrefab;

    // A reference to the player character
    public GameObject player;

    // Flag to determine whether to spawn enemies when the player enters the spawner's trigger
    public bool spawnOnTriggerEnter = true;

    // The time interval between enemy spawns
    public float spawnInterval = 5.0f;

    // The maximum number of enemies that can be spawned
    public int maxEnemies = 10;

    // Flag to determine whether to spawn enemies on start
    public bool spawnOnStart = true;

    // A timer to track the elapsed time since the last enemy spawn
    private float spawnTimer;

    // The current number of enemies in the scene
    private int numEnemies;

    void Start()
    {
        // Reset the spawn timer
        spawnTimer = 0.0f;

        // If the spawnOnStart flag is true, spawn the initial set of enemies
        if (spawnOnStart)
        {
            SpawnEnemies();
        }
    }

    void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // If the spawn timer has reached the spawn interval and the number of enemies is less than the max
        if (spawnTimer >= spawnInterval && numEnemies < maxEnemies)
        {
            // Reset the spawn timer
            spawnTimer = 0.0f;

            // Spawn a new enemy
            SpawnEnemy();
        }
    }

    void SpawnEnemies()
    {
        // Spawn the maximum number of enemies
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the spawnOnTriggerEnter flag is true and the player has entered the trigger
        if (spawnOnTriggerEnter && other.gameObject == player)
        {
            // Check if the number of enemies is less than the max
            if (numEnemies < maxEnemies)
            {
                // Spawn a new enemy
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        // Instantiate a new enemy object at the spawner's position
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Increment the number of enemies
        numEnemies++;
    }
}