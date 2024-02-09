using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    int timeToEnd;

    bool gamePaused = false;
    bool endGame = false;
    bool win = false;

    public int Points = 0;

    public int RedKeys, GreenKeys, BlueKeys = 0;


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (timeToEnd <= 0)
            timeToEnd = 100;

        InvokeRepeating(nameof(Stopper), 2, 1);
    }

    void Update()
    {
        PauseCheck();
        PickupStatistics();
    }

    void Stopper()
    {
        timeToEnd--;
        print("Time: " + timeToEnd + "s");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
            EndGame();
    }

    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));

        if (win)
        {
            print("WON !!!!");
        }
        else
        {
            print("FAIL :(");
        }
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused == true)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause game");
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume game");
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void AddPoints(int points)
    {
        Points += points;
    }

    public void AddTime(int timeToAdd)
    {
        timeToEnd += timeToAdd;
    }

    public void FreezTime(int time)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), time, 1);
    }

    void PickupStatistics()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Current timeToEnd: " + timeToEnd);
            print("Keys: red: " + RedKeys + " green: " + GreenKeys + " Blue: " + BlueKeys);
            print("Points: " + Points);
        }
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.RedKey)
            RedKeys++;
        else if (color == KeyColor.GreenKey)
            GreenKeys++;
        else if (color == KeyColor.BlueKey)
            BlueKeys++;
    }
}
