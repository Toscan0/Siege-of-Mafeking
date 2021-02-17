using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayButton playButton;

    private static string teamName = "";
    private static string userName = "";

    private void Awake()
    {
        CheckTeamName.OnTeamNameChoosen += UpdateTeamName;
        CheckUserName.OnUserNameChoosen += UpdateUserName;
    }

    private void UpdateUserName(string newName)
    {
        userName = newName;

        CheckNames();
    }

    private void UpdateTeamName(string newName)
    {
        if(newName == "None")
        {
            teamName = "";
        }
        else
        {
            teamName = newName;
        }

        CheckNames();
    }

    private void CheckNames()
    {
        if(teamName.Trim() != "" && userName.Trim() != "")
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
        CheckTeamName.OnTeamNameChoosen -= UpdateTeamName;
        CheckUserName.OnUserNameChoosen -= UpdateUserName;
    }
}
