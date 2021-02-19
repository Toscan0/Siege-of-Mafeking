using UnityEngine;

public class MSGReceiver : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IMessageable messageable = collision.gameObject.GetComponent<IMessageable>();
        if (messageable != null)
        {
            messageable.DeliverMSG();
        }
    }
}
