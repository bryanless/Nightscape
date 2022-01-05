using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject obj;
    public GameObject player;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;
    private int lifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<PlayerMovement>().gameObject;
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
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            projectile.GetComponent<EnemyProjectileDamage>().damage = Random.Range(minDamage, maxDamage);
            Destroy(projectile, lifeTime);
            StartCoroutine(ShootPlayer());
        }


    }


}
