using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SteamValve : MonoBehaviour
{


    public Lever lever; // Reference to the pressure plate script

    public PlayerController playerController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Robot")
        {
            if (lever.isActivated)
            {
                Debug.Log("leveer is activated");
                playerController.StartFlight();
            }
    }
    }
}
