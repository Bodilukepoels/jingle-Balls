using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // The radius in which the player can pick up items
    public float pickupRadius = 1.0f;

    void Update()
    {
        // If the player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Get a list of all colliders within the pickup radius
            Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius);

            // Loop through each collider
            foreach (Collider collider in colliders)
            {
                // If the collider is tagged as an "Item"
                if (collider.tag == "Item")
                {
                    // Pick up the item
                    PickUpItem(collider.gameObject);
                }
            }
        }
    }

    void PickUpItem(GameObject item)
    {
        // Add the item to the player's inventory

        // Destroy the item game object
        Destroy(item);
    }
}