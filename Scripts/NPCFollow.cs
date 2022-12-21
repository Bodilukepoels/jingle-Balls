using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    // A reference to the player character
    public GameObject player;

    // The NPC's movement speed
    public float movementSpeed = 3.0f;

    void Update()
    {
        // Calculate the direction to the player
        Vector2 direction = player.transform.position - transform.position;

        // Normalize the direction
        direction.Normalize();

        // Move the NPC towards the player
        transform.position += (Vector3)direction * movementSpeed * Time.deltaTime;
    }
}
