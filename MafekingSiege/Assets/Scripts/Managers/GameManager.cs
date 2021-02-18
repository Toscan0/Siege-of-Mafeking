using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string TeamName { get; private set; } = "";
    public static string UserName { get; private set; } = "";
    public static bool PlayerLost { get; private set; } = false; // false = time over

    private void Awake()
    {
        DefineTeamName.OnTeamNameChoosen += UpdateTeamName;
        DefineUserName.OnUserNameChoosen += UpdateUserName;
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
    }
}
