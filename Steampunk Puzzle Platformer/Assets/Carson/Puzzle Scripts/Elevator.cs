using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float movementDistance = 5f; // Adjust the movement distance as needed
    public float movementSpeed = 2f;
    public bool isMovingUp = true;

    public PressurePlate pressurePlate; // Reference to the pressure plate script

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        // Check if the pressure plate is activated
        if (pressurePlate.isActivated)
        {
            // Elevator movement logic as before
            if (isMovingUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPosition + Vector3.up * movementDistance, movementSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startingPosition + Vector3.up * movementDistance) < 0.1f)
                {
                    isMovingUp = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPosition, movementSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startingPosition) < 0.1f)
                {
                    isMovingUp = true;
                }
            }
        }
        else {
            //pass
        }
    }
}

