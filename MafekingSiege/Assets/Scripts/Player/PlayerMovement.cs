using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;

    private Rigidbody2D rb2D;
    
    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    internal void Move(Vector2 pos)
    {
        rb2D.MovePosition(rb2D.position + pos * movementSpeed);
    }
}