using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNames : MonoBehaviour
{
    [SerializeField]
    private PlayButton playButton;

    private string teamName = "";
    private string userName = "";

    private void Awake()
    {
        DefineTeamName.OnTeamNameChoosen += UpdateTeamName;
        DefineUserName.OnUserNameChoosen += UpdateUserName;
    }

    private void UpdateUserName(string newName)
    {
        userName = newName;

        Check();
    }

    private void UpdateTeamName(string newName)
    {
        if (newName == "None")
        {
            teamName = "";
        }
        else
        {
            teamName = newName;
        }

        Check();
    }

    private void Check()
    {
        if (teamName.Trim() != "" && userName.Trim() != "")
        {
            playButton.SetInteractable(true);
        }
        else
        {
            playButton.SetInteractable(false);
        }
    }

    private void OnDestroy()
    {
        DefineTeamName.OnTeamNameChoosen -= UpdateTeamName;
        DefineUserName.OnUserNameChoosen -= UpdateUserName;
    }
}
