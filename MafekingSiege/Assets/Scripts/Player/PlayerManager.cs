using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerSoundManager))]
public class PlayerManager : MonoBehaviour, IDamageable
{
    public static Action OnPlayerDeath;

    // Health
    [SerializeField]
    private HealthBar healthBar;
    private const int maxHealth = 100;
    private int currentHealth = 0;
    private bool isDead = false;

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
        currentHealth = maxHealth;
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
        if (!isDead) {
            playerMovement.Move(new Vector2(horizontalMove, verticalMove) * Time.fixedDeltaTime);
        }
    }

    void IDamageable.TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if(currentHealth < 0)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);

            isDead = true;
            OnPlayerDeath?.Invoke();

            return;
        }
        healthBar.SetHealth(currentHealth);
        //TODO PLayer blink
    }
}