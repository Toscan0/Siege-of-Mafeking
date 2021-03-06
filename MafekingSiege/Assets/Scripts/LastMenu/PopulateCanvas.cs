﻿using UnityEngine;
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
        //string teamName = "Team: " + GameManager.TeamName;
        //string userName = "Jogador: " + GameManager.UserName;
        string timer = "Timer: " + ((10 * 60) - TimerManager.CurrentTime);
        string Points = "Points: " + GameManager.Points;
        string Score = "Total Score: " + ScoreCalculator(TimerManager.CurrentTime, GameManager.Points);

        text.text = timer + "\n" +
            Points + "\n" +
            Score + "\n";
    }

    private float ScoreCalculator(float time, int points)
    {
        float t = ((10 * 60) - time);

        // TODO: update formula
        return points * 10000 + t;
    }
}
