using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // A reference to the player's sword
    public GameObject sword;

    // The amount of damage the player's sword does
    public int swordDamage = 20;

    void Update()
    {
        // If the player left clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the raycast hits an enemy
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Enemy")
            {
                // Get a reference to the enemy's health component
                Health enemyHealth = hit.collider.GetComponent<Health>();

                // If the enemy's health is greater than 0
                if (enemyHealth.currentHealth > 0)
                {
                    // Attack the enemy and reduce its health by the sword damage amount
                    enemyHealth.TakeDamage(swordDamage);
                }
            }
        }
    }
}
