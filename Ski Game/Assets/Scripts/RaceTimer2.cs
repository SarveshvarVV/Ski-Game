using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // for course 4 session 3


public class RaceTimer2 : MonoBehaviour
{

    public bool raceStarted = false;
    public static float time = 0;
    private TimeSpan timePlaying;

    public string[] formattedTimes;
    private float[] savedTimes = { 0, 0, 0, 0, 0 };

    public TextMeshProUGUI timerText; // for course 4 session 3


    //public 
    private void OnEnable()
    {
        GameEvents.OnRaceStart += StartTimer;
        GameEvents.OnRaceStop += StopTimer;
    
    }

    private void OnDisable()
    {
        GameEvents.OnRaceStart -= StartTimer;
        GameEvents.OnRaceStop -= StopTimer;     
    }


    private void StartTimer()
    {
        time = 0;
        StartCoroutine("Timer");
        raceStarted = true;

        //display our timer
        timerText.gameObject.transform.parent.gameObject.SetActive(true);
    }

    public void StopTimer()
    {
        if (raceStarted)
        {
            StopCoroutine("Timer");
            print("RACE TIME: "+timePlaying.ToString("mm':'ss':'ff"));       
        }
    }
    // functioning timer, counting up until the coroutine is stopped
    private IEnumerator Timer()
    {
        while (true)
        {
            time += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(time);
            // for course 4 session 3
            //format our time for our text f
            if (timePlaying.Minutes > 0) 
                timerText.text = timePlaying.ToString("m':'ss':'ff");
            else
                timerText.text = timePlaying.ToString("s':'ff"); 

            yield return null;
        }
    }

}