using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerSoundManager))]
public class PlayerManager : MonoBehaviour, IDamageable, IMessageable
{
    public static Action OnPlayerDeath;
    public static Action OnMSGDelivered;

    // MSG
    [SerializeField]
    private MSGCanvas MSGCanvas;
    [SerializeField]
    private AudioClip MSGReceived;
    [SerializeField]
    private AudioClip MSGDelivered;
    private bool hasMessage = false;

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
    private Animator animator;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSoundManager = GetComponent<PlayerSoundManager>();
        animator = GetComponent<Animator>();
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

        animator.SetFloat("Horizontal", horizontalMove);
        animator.SetFloat("Vertical", verticalMove);
        animator.SetFloat("Speed", new Vector2(horizontalMove, verticalMove).normalized.sqrMagnitude);
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
        if(currentHealth <= 0)
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

    bool IMessageable.TakeMSG()
    {
        if (!hasMessage)
        {
            hasMessage = true;
            playerSoundManager.PlaySound(MSGReceived);
            MSGCanvas.UpdateImageVisibility(true);

            return true;
        }
        return false;
    }

    bool IMessageable.DeliverMSG()
    {
        if (hasMessage)
        {
            hasMessage = false;
            playerSoundManager.PlaySound(MSGDelivered);
            OnMSGDelivered?.Invoke();
            MSGCanvas.UpdateImageVisibility(false);

            return true;
        }
        return false;
    }
}