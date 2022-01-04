using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject obj;
    public Transform player;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            GameObject projectile = Instantiate(obj, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.position;
            Vector2 direction = (targetPos - myPos).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            projectile.GetComponent<EnemyProjectileDamage>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }


    }
}
