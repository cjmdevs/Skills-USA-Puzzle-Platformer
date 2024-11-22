using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActivated = false;
    public Animator animator;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isActivated == true) {
                isActivated = false;
                animator.SetBool("isFlipping", false);
                Debug.Log("is flipping true");
            }
            else {
                isActivated = true;
                animator.SetBool("isFlipping", true);
                Debug.Log("is flipping true");
            }

        }
    }

    
}
