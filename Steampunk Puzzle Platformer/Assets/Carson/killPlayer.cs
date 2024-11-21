using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Robot")){
            gameManager.GameOver();
            Debug.Log("Dead");
        }
    }
}
