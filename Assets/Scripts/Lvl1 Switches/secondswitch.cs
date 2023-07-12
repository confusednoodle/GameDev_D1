using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class secondswitch : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform switchTrans;
    [SerializeField] Material colour;
    private bool pressed = false;
    [SerializeField] AudioSource sound;

    // add switch specific vars here
    [SerializeField] GameObject movingPlatform;

    public float speed = 2f; // Speed at which the platform moves
    public float distance = 20f; // Distance the platform moves

    private bool movingRight = true; // Flag to determine the direction of movement
    private Vector3 initialPosition; // Initial position of the platform

    void Start()
    {
        initialPosition = movingPlatform.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        // keep colour red
        if (!pressed)
        {
            colour.color = new Color(1, 0, 0);
        }

        // Calculate the target position based on the direction of movement
        Vector3 targetPosition = movingRight ? initialPosition + new Vector3(distance, 0f, 0f) : initialPosition;

        // Move the platform towards the target position
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (movingPlatform.transform.position == targetPosition)
        {
            // Change the direction of movement
            movingRight = !movingRight;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // what happens on first press
        if ((collision.gameObject == player) && !pressed)
        {
            sound.Play();
            pressed = true;
            // avoid y fighting
            switchTrans.position -= new Vector3(0, 0.09f, 0);
            colour.color = new Color(0, 1, 0);

            // add specific switch functionality here
            movingPlatform.SetActive(true);
        }
    }
}
