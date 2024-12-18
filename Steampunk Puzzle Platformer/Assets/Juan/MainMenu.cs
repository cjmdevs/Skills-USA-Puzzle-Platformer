using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public string mainMenuScene = "Main Menu";
    public string tutorialScene = "tutorial";
    public string scene2 = "level 2";
    public string scene1 = "Test scene";

    public Stopwatch stopwatch;
    // Start is called before the first frame update
    public void scene2Game()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        SceneManager.LoadScene(scene2);
        Cursor.visible = false;
        
    }

    public void scene1Game()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        SceneManager.LoadScene(scene1);
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
