using UnityEngine;
using UnityEngine.UI;

public class UpdatePointsText : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private float points = 0;

    private void Awake()
    {
        PlayerManager.OnMSGDelivered += IncrPoints;
    }

    private void IncrPoints()
    {
        points++;
        text.text = "Points: " + points;
    }

    private void OnDestroy()
    {
        PlayerManager.OnMSGDelivered -= IncrPoints;
    }
}
