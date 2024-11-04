using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActivated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isActivated == true) {
                isActivated = false;
            }
            else {
                isActivated = true;
            }

        }
    }

    
}
