using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static Action OnTimeOver;
    public static float CurrentTime { get; private set; } = 10 * 60; //in minutes

    [SerializeField]
    private Text timerText;

    private bool stopTimer = false;

    void Start()
    {
        SetTimerText();
    }

    void Update()
    {
        if (CurrentTime > 0 && stopTimer == false)
        {
            CurrentTime -= Time.deltaTime;
        }
        else if(CurrentTime <= 0 && stopTimer == false)
        {
            stopTimer = true;
            CurrentTime = 0;

            OnTimeOver?.Invoke();
        }
        SetTimerText();
    }
    
    private void SetTimerText()
    {
        if (timerText != null)
        {
            timerText.text = GetTimerAsString(CurrentTime);
        }
    }


    ////
    private string GetTimerAsString(float timer)
    {
        return GetMinutes(timer)
        + ":" + GetSecondsToDisplay(timer) + ":"
        + GetMilliseconds(timer);
    }

    private string GetMinutes(float seconds)
    {
        return ((int)seconds / 60).ToString();
    }

    private string GetSecondsToDisplay(float seconds)
    {
        return (seconds % 60).ToString("f0");
    }

    private string GetMilliseconds(float seconds)
    {
        return ((seconds * 1000) % 1000).ToString("f0");
    }
}