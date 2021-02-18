using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerSoundManager))]
public class PlayerManager : MonoBehaviour, IDamageable
{
    // Health
    [SerializeField]
    private HealthBar healthBar;
    private const int maxHealth = 100;
    private int currentHealth = 0;

    //Movement
    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    private PlayerMovement playerMovement;
    private PlayerSoundManager playerSoundManager;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSoundManager = GetComponent<PlayerSoundManager>();
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // move player
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        playerMovement.Move(new Vector2 (horizontalMove, verticalMove) * Time.fixedDeltaTime);
    }

    void IDamageable.TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }
}