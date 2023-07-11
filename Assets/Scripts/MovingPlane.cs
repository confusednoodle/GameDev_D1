using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlane : MonoBehaviour
{
    public float speed = 2f; // Speed at which the platform moves
    public float distance = 20f; // Distance the platform moves

    private bool movingRight = true; // Flag to determine the direction of movement
    private Vector3 initialPosition; // Initial position of the platform

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the target position based on the direction of movement
        Vector3 targetPosition = movingRight ? initialPosition + new Vector3(distance, 0f, 0f) : initialPosition;

        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (transform.position == targetPosition)
        {
            // Change the direction of movement
            movingRight = !movingRight;
        }
    }
}
