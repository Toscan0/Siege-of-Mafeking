using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MSGReceiver : MonoBehaviour
{
    [SerializeField]
    private ReceiverMSGSpawner receiverMSGSpawner;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SelectNPC();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IMessageable messageable = collision.gameObject.GetComponent<IMessageable>();
        if (messageable != null)
        {
            bool msgReceived = messageable.DeliverMSG();

            if (msgReceived)
            {
                receiverMSGSpawner.ReceiverEnabled = false;
                gameObject.SetActive(false);
            }
        }
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
