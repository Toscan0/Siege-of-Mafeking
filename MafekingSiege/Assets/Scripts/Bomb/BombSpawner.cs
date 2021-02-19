﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bombPrefab;

    private float minReloadTime = 4.5f;
    private float maxReloadTime = 5.5f;
    private int launchProbability = 20;

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
            if (UnityEngine.Random.Range(0, 100) <= launchProbability)
            {
                Instantiate(bombPrefab, gameObject.transform.position, Quaternion.identity);
            }            
        }
    }
}
