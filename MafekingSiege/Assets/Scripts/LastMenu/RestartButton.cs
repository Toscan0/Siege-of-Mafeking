using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        PostOnServer.OnDataSended += EnableButton;

        button = GetComponent<Button>();
    }

    private void EnableButton()
    {
        button.interactable = true;

        // TODO : RESTART
    }

    private void OnDestroy()
    {
        PostOnServer.OnDataSended -= EnableButton;
    }
}
