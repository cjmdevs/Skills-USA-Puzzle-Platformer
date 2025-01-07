using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialWin : MonoBehaviour
{
    public GameObject Player;
    public GameObject Robot;
    public GameObject LoseUI;
    public GameObject WinUI;

    public Stopwatch stopwatch;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        WinUI.SetActive(true);
        Player.SetActive(false);
        Robot.SetActive(false);
        Cursor.visible = true;
        stopwatch.StopStopwatch();
    }
}
