using UnityEngine;

public class SendToServer : MonoBehaviour
{
    [SerializeField]
    private PostOnServer postOnServer;
    [SerializeField]
    private bool sendData = true;

    private void Start()
    {
        if (sendData)
        {
            postOnServer.SendData(
                GameManager.TeamName,
                GameManager.UserName,
                GameManager.UserName,
                GameManager.UserName
                );

            postOnServer.SendData(
                "BD",
                "AI",
                "555555",
                "111");
        }
    }
}
