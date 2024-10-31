using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target; // Reference to the player to follow

    private void LateUpdate() // LateUpdate ensures camera updates after character movement
    {
        if (target != null)
        {
            transform.position = target.position + new Vector3(0, 5, -10); // Offset the camera position behind the player
            transform.LookAt(target); // Make the camera look at the target
        }
    }

    public void SetTarget(Transform newTarget) // Function to update the target player
    {
        target = newTarget;
    }
}

