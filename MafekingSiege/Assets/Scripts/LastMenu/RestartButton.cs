using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    }

    public void Restart()
    {
        // RELOAD PAGE
    }

    private void OnDestroy()
    {
        PostOnServer.OnDataSended -= EnableButton;
    }
}
