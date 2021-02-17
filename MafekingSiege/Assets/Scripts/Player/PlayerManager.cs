using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerSoundManager))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    private PlayerMovement playerMovement;
    private PlayerSoundManager playerSoundManager;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSoundManager = GetComponent<PlayerSoundManager>();
    }

    void Update()
    {
        // move player
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerMovement.HorizontalMove(transform.right * horizontalMove *
            Time.deltaTime * movementSpeed);

        playerMovement.VerticalMove(transform.up * verticalMove *
            Time.deltaTime * movementSpeed);
    }
}