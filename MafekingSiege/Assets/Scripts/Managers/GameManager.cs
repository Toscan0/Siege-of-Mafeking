using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string TeamName { get; private set; } = "";
    public static string UserName { get; private set; } = "";
    public static bool PlayerLost { get; private set; } = false; // false = time over
    public static int Points { get; private set; } = 0; // false = time over
    
    private void Awake()
    {
        DefineTeamName.OnTeamNameChoosen += UpdateTeamName;
        TimerManager.OnTimeOver += TimeOver;
        PlayerManager.OnPlayerDeath += PlayerDeath;
        PlayerManager.OnMSGDelivered += IncrPoints;
    }

    private void IncrPoints()
    {
        Points++;

        BombSpawner.LaunchProbability++;

        if (Points % 5 == 0)
        {
            BombSpawner.LaunchProbability++;
        }
        if (Points % 10 == 0)
        {
            BombSpawner.LaunchProbability++;
        }
    }
    

    private void PlayerDeath()
    {
        PlayerLost = true;
    }

    private void TimeOver()
    {
        PlayerLost = false;
    }

    private void UpdateUserName(string newName)
    {
        UserName = newName;
    }

    private void UpdateTeamName(string newName)
    {
        if(newName == "None")
        {
            TeamName = "";
        }
        else
        {
            TeamName = newName;
        }
    }

    private void OnDestroy()
    {
        DefineTeamName.OnTeamNameChoosen -= UpdateTeamName;
        TimerManager.OnTimeOver -= TimeOver;
        PlayerManager.OnPlayerDeath -= PlayerDeath;
        PlayerManager.OnMSGDelivered -= IncrPoints;
    }
}
