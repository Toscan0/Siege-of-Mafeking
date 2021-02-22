using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class MSGDeliver : MonoBehaviour
{
    private bool hasMSG = false;
    private int msgProbability = 50;
    private float minReloadTime = 0.5f;
    private float maxReloadTime = 3f;

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
            if (!hasMSG)
            {
                if (UnityEngine.Random.Range(0, 100) <= msgProbability)
                {
                    NewMSG();
                }
                else
                {
                    NoMSG();
                }
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(minReloadTime, maxReloadTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMSG)
        {
            IMessageable messageable = collision.gameObject.GetComponent<IMessageable>();
            if (messageable != null)
            {
                bool msgReceived = messageable.TakeMSG();

                if (msgReceived)
                {
                    NoMSG();
                }
            }
        }
    }

    private void NoMSG()
    {
        spriteRenderer.enabled = false;
        col2D.enabled = false;
        hasMSG = false;
    }

    private void NewMSG()
    {
        SelectNPC();

        spriteRenderer.enabled = true;
        col2D.enabled = true;
        hasMSG = true;
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
