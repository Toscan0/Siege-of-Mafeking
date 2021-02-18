using UnityEngine;

public class PopulateCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverTitle;
    [SerializeField]
    private GameObject timeOverTitle;

    private void Start()
    {
        PopulateTitle();
    }

    private void PopulateTitle()
    {
        if (GameManager.PlayerLost)
        { // Game Over
            gameOverTitle.SetActive(true);
            timeOverTitle.SetActive(false);
        }
        else
        { // Time over
            gameOverTitle.SetActive(false);
            timeOverTitle.SetActive(true);
        }
    }

    private void PopulateText()
    {
        string teamName = "Team: " + GameManager.TeamName;
        string userName = "User: " + GameManager.UserName;
        string timer = "Timer: " + GameManager.UserName;
        string Points = "User: " + GameManager.UserName;
    }
}
