using System.Collections;
using UnityEngine;

public class BombSpawner : BombSpawnerAbstract
{
    [SerializeField]
    private GameObject bombPrefab;

    private float minReloadTime = 2.5f;
    private float maxReloadTime = 5f;
    

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1.7f, 1.7f, 1));
    }

    private void Start()
    {
        StartCoroutine(LaunchBomb());   
    }

    private IEnumerator LaunchBomb()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minReloadTime, maxReloadTime));

            // k% of launch bomb
            if (UnityEngine.Random.Range(0, 100) <= LaunchProbability)
            {
                Instantiate(bombPrefab, gameObject.transform.position, Quaternion.identity);
            }            
        }
    }
}
