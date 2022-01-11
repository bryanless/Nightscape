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
    public GameObject slime;
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
            // Start spinning
            slime.GetComponent<Animator>().SetBool("isSpinning", true);
            yield return new WaitForSeconds(0.5f);

            // Bullet 1
            GameObject projectile = Instantiate(obj, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            projectile.GetComponent<EnemyProjectileDamage>().damage = Random.Range(minDamage, maxDamage);
            yield return new WaitForSeconds(1);

            // Bullet 2
            GameObject projectile2 = Instantiate(obj, transform.position, Quaternion.identity);
            Vector2 myPos2 = transform.position;
            Vector2 targetPos2 = player.transform.position;
            Vector2 direction2 = (targetPos2 - myPos2).normalized;
            projectile2.GetComponent<Rigidbody2D>().velocity = direction2 * projectileForce;
            projectile2.GetComponent<EnemyProjectileDamage>().damage = Random.Range(minDamage, maxDamage);

            // Stop spinning
            slime.GetComponent<Animator>().SetBool("isSpinning", false);
            Destroy(projectile, lifeTime);
            StartCoroutine(ShootPlayer());
        }
    }
}
