using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    // The mini boss's maximum health
    public int maxHealth = 1000;

    // The mini boss's current health
    public int currentHealth;

    // The amount of damage dealt by the mini boss's first attack
    public int attack1Damage = 50;

    // The amount of damage dealt by the mini boss's second attack
    public int attack2Damage = 25;

    // The amount of damage dealt by the mini boss's third attack
    public int attack3Damage = 100;

    void Start()
    {
        // Set the mini boss's current health to its maximum health
        currentHealth = maxHealth;
    }

    void Update()
    {
        // If the mini boss's health is below or equal to 0
        if (currentHealth <= 0)
        {
            // Destroy the mini boss
            Destroy(gameObject);
        }
    }

    public void Attack()
    {
        // Generate a random number between 1 and 3
        int attackNumber = Random.Range(1, 4);

        // If the attack number is 1
        if (attackNumber == 1)
        {
            // Deal attack1Damage damage to the player
            DealDamage(attack1Damage);
        }
        // If the attack number is 2
        else if (attackNumber == 2)
        {
            // Deal attack2Damage damage to the player
            DealDamage(attack2Damage);
        }
        // If the attack number is 3
        else if (attackNumber == 3)
        {
            // Deal attack3Damage damage to the player
            DealDamage(attack3Damage);
        }
    }

    void DealDamage(int damage)
    {
        // Decrease the player's health by the specified amount of damage
        PlayerController.instance.health -= damage;
    }
}
