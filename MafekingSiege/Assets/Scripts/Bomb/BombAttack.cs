using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    private const int damage = 10;

    internal void Attack(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}
