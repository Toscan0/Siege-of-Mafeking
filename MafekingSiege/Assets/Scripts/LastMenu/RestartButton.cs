using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Button button;

    [DllImport("__Internal")]
    private static extern void Hello();

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
        Hello();
    }

    private void OnDestroy()
    {
        PostOnServer.OnDataSended -= EnableButton;
    }
}
