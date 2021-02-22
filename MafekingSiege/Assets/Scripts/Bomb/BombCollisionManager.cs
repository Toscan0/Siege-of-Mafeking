using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BombSoundManager))]
[RequireComponent(typeof(BombAttack))]
public class BombCollisionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionAnim;
    [SerializeField]
    private AudioClip explosionSound;

    private BombSoundManager bombSoundManager;
    private BombAttack bombAttack;

    private void Awake()
    {
        bombSoundManager = GetComponent<BombSoundManager>();
        bombAttack = GetComponent<BombAttack>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null)
        {
            bombAttack.Attack(damageable);
        }

        
        ExplodeBomb(collision.gameObject.transform.position);
    }

    private void ExplodeBomb(Vector3 collisionPos)
    {
        bombSoundManager.PlaySound(explosionSound);
        Instantiate(explosionAnim, new Vector3(gameObject.transform.position.x, collisionPos.y, 0), Quaternion.identity);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;

        Destroy(gameObject, 1f);
    }
}
