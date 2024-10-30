using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isActivated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Robot")
        {
            isActivated = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Robot")
        {
            isActivated = false;
        }
    }
}
