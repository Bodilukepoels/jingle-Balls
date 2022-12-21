using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionFollow : MonoBehaviour
{
    // The target that the companion should follow
    public Transform target;

    // The speed at which the companion should move
    public float followSpeed = 2.0f;

    // The distance that the companion should maintain from the target
    public float followDistance = 1.0f;

    // The minimum distance that the companion should maintain from the target
    public float followMinDistance = 0.5f;

    // The maximum distance that the companion should maintain from the target
    public float followMaxDistance = 3.0f;

    // The distance that the companion should start moving towards the target
    public float followStartDistance = 5.0f;

    // The distance that the companion should stop moving towards the target
    public float followStopDistance = 10.0f;

    // The distance that the companion should start moving away from the target
    public float followAwayDistance = 15.0f;

    // The distance that the companion should stop moving away from the target
    public float followAwayStopDistance = 20.0f;

    // The offset that the companion should maintain from the target
    public Vector3 followOffset = Vector3.zero;

    private void Update()
    {
        // Calculate the distance between the companion and the target
        float distance = Vector3.Distance(transform.position, target.position);

        // If the distance is greater than the follow start distance, move towards the target
        if (distance > followStartDistance)
        {
            // Calculate the direction towards the target
            Vector3 direction = (target.position + followOffset - transform.position).normalized;

            // Move towards the target at the follow speed
            transform.position += direction * followSpeed * Time.deltaTime;
        }

        // If the distance is less than the follow stop distance, stop moving towards the target
        if (distance < followStopDistance)
        {
            // Stop moving
            transform.position = transform.position;
        }

        // If the distance is greater than the follow away distance, move away from the target
        if (distance > followAwayDistance)
        {
            // Calculate the direction away from the target
            Vector3 direction = (transform.position - target.position - followOffset).normalized;

            // Move away from the target at the follow speed
            transform.position += direction * followSpeed * Time.deltaTime;
        }

        // If the distance is less than the follow away stop distance, stop moving away from the target
        if (distance < followAwayStopDistance)
        {
            // Stop moving
            transform.position = transform.position;
        }

        // If the distance is between the follow distance and follow min distance, move towards the target
        if (distance > followDistance && distance < followMinDistance)
        {
            // Calculate the direction towards the target
            Vector3 direction = (target.position + followOffset - transform.position).normalized;

            // Move towards the target at the follow speed
            transform.position += direction * followSpeed * Time.deltaTime;
        }

        // If the distance is between the follow max distance and follow distance, move away
    }
}