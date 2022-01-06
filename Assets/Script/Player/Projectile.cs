using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject obj;
    public GameObject player;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float projectileCooldown;
    private float projectileCooldownDuration;
    private int lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        projectileCooldownDuration = projectileCooldown;
        lifeTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        projectileCooldownDuration -= Time.deltaTime;

        if (PauseMenu.isPaused)
        {
            return;
        }
        if (Input.GetMouseButton(1) && projectileCooldownDuration <= 0)
        {
            if (player != null)
            {
                GameObject projectile = Instantiate(obj, player.transform.position, Quaternion.identity);
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPos = transform.position;
                Vector2 direction = (mousePos - myPos).normalized;
                var angle = Mathf.Atan2(direction.y, direction.x);
                angle *= (180 / Mathf.PI);

                projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                projectile.GetComponent<ProjectileDamage>().damage = Random.Range(minDamage, maxDamage);

                projectileCooldownDuration = projectileCooldown;

                Destroy(projectile, lifeTime);
            }
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(projectileCooldown);
        if (player != null)
        {
            GameObject projectile = Instantiate(obj, player.transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x);
            angle *= (180 / Mathf.PI);

            projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            projectile.GetComponent<ProjectileDamage>().damage = Random.Range(minDamage, maxDamage);

            Destroy(projectile, lifeTime);
        }
    }
}
