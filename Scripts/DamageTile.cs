using UnityEngine;
using Health;

public class DamageTile : MonoBehaviour
{
    // The amount of damage the tile will deal to the player
    public int damage = 10;

    // A reference to the player's health script
    public Health playerHealth;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger
        if (other.CompareTag("Player"))
        {
            // Deal damage to the player
            playerHealth.TakeDamage(damage);

            // Update the player's health display
            playerHealth.UpdateHealthDisplay();
        }
        
    }
    public void UpdateHealthDisplay()
    {
        // Set the text of the healthText UI element to the player's current health
        healthText.text = currentHealth.ToString();
    }
}
