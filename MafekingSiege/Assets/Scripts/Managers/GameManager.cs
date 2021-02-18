using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string TeamName { get; private set; } = "";
    public static string UserName { get; private set; } = "";
    public static bool PlayerLost { get; private set; } = false; // false = time over

    [SerializeField]
    private LoadSceneManager loadSceneManager;

    private void Awake()
    {
        DefineTeamName.OnTeamNameChoosen += UpdateTeamName;
        DefineUserName.OnUserNameChoosen += UpdateUserName;
        TimerManager.OnTimeOver += TimeOver;
    }

    private void TimeOver()
    {
        PlayerLost = false;
        loadSceneManager.LoadNextScene();
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
    }
}
