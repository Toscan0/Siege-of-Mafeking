using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RestartButton : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        PostOnServer.OnDataSended += EnableText;
        text = GetComponent<Text>();
    }

    private void EnableText()
    {
        text.enabled = true;
    }

    private void OnDestroy()
    {
        PostOnServer.OnDataSended -= EnableText;
    }
}
