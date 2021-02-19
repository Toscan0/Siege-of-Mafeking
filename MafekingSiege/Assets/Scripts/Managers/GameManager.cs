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
        DefineUserName.OnUserNameChoosen += UpdateUserName;
        TimerManager.OnTimeOver += TimeOver;
        PlayerManager.OnPlayerDeath += PlayerDeath;
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
        DefineUserName.OnUserNameChoosen -= UpdateUserName;
        TimerManager.OnTimeOver -= TimeOver;
        PlayerManager.OnPlayerDeath -= PlayerDeath;
    }
}
