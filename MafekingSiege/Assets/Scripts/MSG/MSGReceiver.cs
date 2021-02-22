using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class MSGReceiver : MonoBehaviour
{
    
    private bool canRecive = false;
    private int msgProbability = 50;
    private float minReloadTime = 0.5f;
    private float maxReloadTime = 2f;

    private SpriteRenderer spriteRenderer;
    private Collider2D col2D;
    private Animator animator;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(SpawnMSG());
    }

    private IEnumerator SpawnMSG()
    {
        while (true)
        {
            if (!canRecive)
            {
                if (UnityEngine.Random.Range(0, 100) <= msgProbability)
                {
                    CanRecive();
                }
                else
                {
                    CanNotReceive();
                }
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(minReloadTime, maxReloadTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IMessageable messageable = collision.gameObject.GetComponent<IMessageable>();
        if (messageable != null)
        {
            bool msgReceived = messageable.DeliverMSG();

            if (msgReceived)
            {
                CanNotReceive();
            }
        }
    }

    private void CanNotReceive()
    {
        spriteRenderer.enabled = false;
        col2D.enabled = false;
        canRecive = false;
    }

    private void CanRecive()
    {
        SelectNPC();

        spriteRenderer.enabled = true;
        col2D.enabled = true;
        canRecive = true;
    }

    private void SelectNPC()
    {
        if (UnityEngine.Random.Range(0, 100) <= 50)
        {
            animator.SetBool("is1", true);
        }
        else
        {
            animator.SetBool("is1", false);
        }
    }
}
