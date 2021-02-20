using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostOnServer : MonoBehaviour
{
    public static Action OnDataSended;

    private const string POST_HIGHSCORE_URL = "" +
        "http://web.tecnico.ulisboa.pt/~ist181633/SCOUTS/Post.php";

    public void SendData(string teamName, string userName, float time, int points)
    {
        string dataToSend = ParseDataToSend(teamName, userName, time, points);

        StartCoroutine(PostData(dataToSend));
    }

    private string ParseDataToSend(string teamName, string userName, float time, int points)
    {
        float score = ScoreCalculator(time, points);

        return teamName + ";" + 
            userName + ";" +
            time + ";" +
            points + ";" +
            "Score: " + score + ";\n";
    }

    private float ScoreCalculator(float time, int points)
    {
        float t = ((10 * 60) - time);

        // TODO: update formula
        return t * points;
    }

    private IEnumerator PostData(string data)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("_content", data));

        UnityWebRequest www = UnityWebRequest.Post(POST_HIGHSCORE_URL, wwwForm);

        //w8 for answer
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("UnityWebRequest post error: " + www.error);
        }

        OnDataSended?.Invoke();
    }
}