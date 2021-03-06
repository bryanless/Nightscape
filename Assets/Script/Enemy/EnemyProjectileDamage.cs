using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileDamage : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            PlayerStats.playerStats.DealDamage(damage);
            Destroy(gameObject);

        } else if (collision.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }


    }
}
