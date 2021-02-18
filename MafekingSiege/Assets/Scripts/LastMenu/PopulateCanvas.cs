using UnityEngine;
using UnityEngine.UI;

public class PopulateCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverTitle;
    [SerializeField]
    private GameObject timeOverTitle;
    [SerializeField]
    private Text text;

    private void Start()
    {
        PopulateTitle();
        PopulateText();
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
        string timer = "Time: " + GameManager.UserName;
        string Points = "Points: " + GameManager.UserName;

        text.text = teamName + "\n" +
            userName + "\n" +
            timer + "\n" +
            Points + "\n";
    }
}
