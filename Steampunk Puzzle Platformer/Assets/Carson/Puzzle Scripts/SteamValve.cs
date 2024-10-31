using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamValve : MonoBehaviour
{
    public void Activate()
    {
        // Trigger the flight effect, perhaps by:
        // 1. Sending a message to the player:
        GameObject.FindGameObjectWithTag("Player").SendMessage("StartFlight");

        // 2. Activating a particle effect:
        ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}
