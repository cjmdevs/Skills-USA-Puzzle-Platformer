using System;

using System.Collections;

using System.Collections.Generic;

using TMPro;

using Unity.Mathematics;

using UnityEngine;

using UnityEngine.UI;





public class Stopwatch : MonoBehaviour

{

public bool stopwatchActive = false;

float currentTime;





public TextMeshProUGUI currentTimeText;







public float mutiplier = 2;

// Start is called before the first frame update

void Start()

{

currentTime = 0;

}



// Update is called once per frame

void Update()

{

if (stopwatchActive == true) {

currentTime = currentTime + Time.deltaTime;

}



TimeSpan time = TimeSpan.FromSeconds(currentTime);

currentTimeText.text = time.ToString(@"mm\:ss");





}



public void StartStopwatch(){

stopwatchActive = true;

}



public void StopStopwatch(){

stopwatchActive = false;

}

}


