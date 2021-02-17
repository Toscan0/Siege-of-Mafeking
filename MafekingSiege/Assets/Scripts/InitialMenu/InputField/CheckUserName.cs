using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUserName : MonoBehaviour
{
    private string selectedUserName = "";

    public void Input_UserNameUpdated(string newName)
    {
        selectedUserName = newName;
    }
}
