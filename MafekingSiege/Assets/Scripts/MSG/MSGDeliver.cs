using System.Collections;
using UnityEngine;

public class MSGDeliver : MonoBehaviour
{
    [SerializeField]
    private GameObject Parchment;

    private bool hasMSG;
    private int msgProbability = 50;
    private float minReloadTime = 1f;
    private float maxReloadTime = 4f;

    private void Start()
    {
        StartCoroutine(SpawnMSG());
    }

    private IEnumerator SpawnMSG()
    {
        while (true)
        {
            if (UnityEngine.Random.Range(0, 100) <= msgProbability)
            {
                NewMSG();
            }
            else
            {
                NoMSG();
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
        Parchment.SetActive(false);
        hasMSG = false;
    }

    private void NewMSG()
    {
        Parchment.SetActive(true);
        hasMSG = true;
    }
}
