using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public string mainMenuScene = "Main Menu";
    public string tutorialScene = "tutorial";
    public string gameScene = "Test scene";
    public Stopwatch stopwatch;
    // Start is called before the first frame update
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        SceneManager.LoadScene(gameScene);
        Cursor.visible = false;
        
    }

    public void StartTutorial()
    {
    SceneManager.LoadScene(tutorialScene);

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
