using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public SteamValve steamValve; // Reference to the steam valve to activate

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            steamValve.Activate();
        }
    }
}
