using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    internal void HorizontalMove(Vector3 pos)
    {
        transform.position += pos;
    }

    internal void VerticalMove(Vector3 pos)
    {
        transform.position += pos;
    }
}