using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Robot;
    public GameObject LoseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver(){
        LoseUI.SetActive(true);
        Player.SetActive(false);
        Robot.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit(){
        Application.Quit();
    }
}
