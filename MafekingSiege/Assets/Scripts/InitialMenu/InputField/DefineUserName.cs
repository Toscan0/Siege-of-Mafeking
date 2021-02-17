using System;
using UnityEngine;

public class DefineUserName : MonoBehaviour
{
    public static Action<string> OnUserNameChoosen;

    private string selectedUserName = "";

    public void Input_UserNameUpdated(string newName)
    {
        selectedUserName = newName;

        OnUserNameChoosen.Invoke(newName);
    }
}
