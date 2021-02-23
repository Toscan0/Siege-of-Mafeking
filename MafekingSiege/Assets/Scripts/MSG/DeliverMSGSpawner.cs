using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverMSGSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn1;
    [SerializeField]
    private GameObject spawn2;

    public bool DealerEnabled { private get; set; } = false;
    private float minReloadTime = 0.5f;
    private float maxReloadTime = 3f;

    private void OnDrawGizmos()
    {
        if (spawn1 != null)
        {
            Gizmos.color = new Color(0, 1, 0, 0.5f);
            Gizmos.DrawCube(spawn1.transform.position, new Vector3(1.5f, 1.5f, 1));
        }
        if (spawn2 != null)
        {
            Gizmos.color = new Color(0, 1, 0, 0.5f);
            Gizmos.DrawCube(spawn2.transform.position, new Vector3(1.5f, 1.5f, 1));
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnMSG());
    }

    private IEnumerator SpawnMSG()
    {
        while (true)
        {
            if (!DealerEnabled)
            {
                if (UnityEngine.Random.Range(0, 100) <= 50)
                { // spawn 1
                    spawn1.SetActive(true);
                    spawn2.SetActive(false);
                    DealerEnabled = true;
                }
                else
                { // spawn 2
                    spawn1.SetActive(false);
                    spawn2.SetActive(true);
                    DealerEnabled = true;
                }
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(minReloadTime, maxReloadTime));
        }
    }
}
