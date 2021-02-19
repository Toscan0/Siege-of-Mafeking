using UnityEngine;

public class MSGDeliver : MonoBehaviour
{
    [SerializeField]
    private GameObject Parchment;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IMessageable messageable = collision.gameObject.GetComponent<IMessageable>();
        if (messageable != null)
        {
            bool msgReceived = messageable.TakeMSG();

            if (msgReceived)
            {
                Parchment.SetActive(false);
            }
        }
    }
}
