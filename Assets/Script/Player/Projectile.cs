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
    private int lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused)
        {
            return;
        }
        if (Input.GetMouseButtonDown(1))
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
