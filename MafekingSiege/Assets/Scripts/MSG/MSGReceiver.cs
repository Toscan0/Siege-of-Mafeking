using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSGReceiver : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IMessageable messageable = collision.gameObject.GetComponent<IMessageable>();
        if (messageable != null)
        {
            bool msgReceived = messageable.DeliverMSG();
        }
    }
}
