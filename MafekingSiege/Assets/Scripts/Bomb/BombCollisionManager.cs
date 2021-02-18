using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollisionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionAnim;
    private const int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        gameObject.SetActive(false);

        Instantiate(explosionAnim);
    }
}
