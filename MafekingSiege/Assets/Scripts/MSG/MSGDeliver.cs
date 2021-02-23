using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MSGDeliver : MonoBehaviour
{
    [SerializeField]
    private DeliverMSGSpawner deliverMSGSpawner;

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
            bool msgReceived = messageable.TakeMSG();

            if (msgReceived)
            {
                deliverMSGSpawner.DealerEnabled = false;
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
