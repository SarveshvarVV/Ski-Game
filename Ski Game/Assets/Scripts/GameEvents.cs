using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void raceStartAction();
    public static event  raceStartAction OnRaceStart;

    public delegate void raceFinishAction();
    public static event  raceFinishAction OnRaceStop;


    public delegate void retryRaceAction();
    public static event retryRaceAction OnRetryRace;

    public delegate void nextLevelAction();
    public static event nextLevelAction OnNextLevel;

    public delegate IEnumerator  quitGameAction();
    public static event quitGameAction OnQuitGame;


    public static void StartRace()
    {
        if (OnRaceStart != null)
            OnRaceStart();
    }

    public static void StopRace()
    {
        if (OnRaceStop != null)
            OnRaceStop();
    }


    //Will these are for Course 3: Session 2
    //These will only be called from the inpector so we are not making them static

    public void RetryRace()
    {
        if (OnRetryRace != null)
            OnRetryRace();
    }

    public void NextRace()
    {
        if (OnRetryRace != null)
            OnNextLevel();
    }

    //Registers coroutines as callbacks
    public void QuitGame()
    {
        if (OnQuitGame != null)
            StartCoroutine(OnQuitGame());
    }


}
