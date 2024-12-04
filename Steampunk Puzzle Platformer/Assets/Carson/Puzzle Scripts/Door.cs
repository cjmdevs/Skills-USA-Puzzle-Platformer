using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float movementDistance = 5f; // Adjust the movement distance as needed
    public float movementSpeed = 2f;

    public PressurePlate pressurePlate; // Reference to the pressure plate script

    private Vector3 startingPosition;
    private bool isMoving;
    private bool isMovingUp;

    void Start()
    {
        startingPosition = transform.position;
        isMoving = false;
        isMovingUp = true; // Initial direction can be set as needed
    }

    void Update()
    {
        // Check if the pressure plate is activated and the elevator isn't already moving
        if (pressurePlate.isActivated && !isMoving)
        {
            isMoving = true;
            isMovingUp = true; // Start moving up when activated
        }
        else if (!pressurePlate.isActivated && !isMoving)
        {
            // If the pressure plate is deactivated and the elevator is not moving,
            // start moving down to the original position
            isMoving = true;
            isMovingUp = false;
        }

        // Elevator movement logic
        if (isMoving)
        {
            if (isMovingUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPosition + Vector3.up * movementDistance, movementSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startingPosition + Vector3.up * movementDistance) < 0.1f)
                {
                    isMovingUp = false; // Start moving down
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPosition, movementSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startingPosition) < 0.1f)
                {
                    isMoving = false; // Stop moving
                }
            }
        }
    }
}