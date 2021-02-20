using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

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

    private void OnDestroy()
    {
        PostOnServer.OnDataSended -= EnableButton;
    }


    public void Restart()
    {
        //TODO
    }
}
