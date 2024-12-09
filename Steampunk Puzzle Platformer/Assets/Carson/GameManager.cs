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
    public GameObject WinUI;

    public Stopwatch stopwatch;
    public string mainMenuScene = "Main Menu";


    // Start is called before the first frame update
    void Start()
    {
        stopwatch.StartStopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver(){
        LoseUI.SetActive(true);
        Player.SetActive(false);
        Robot.SetActive(false);
        Cursor.visible = true;
        stopwatch.StopStopwatch();
    }

    public void WinScreen(){
        WinUI.SetActive(true);
        Player.SetActive(false);
        Robot.SetActive(false);
        Cursor.visible = true;
        stopwatch.StopStopwatch();
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit(){
        Application.Quit();
    }

    public void tutorialComplete()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
