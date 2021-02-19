using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMSG : MonoBehaviour
{
    private int launchProbability = 20;


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1.7f, 1.7f, 1));
    }
}
