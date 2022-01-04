using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject obj;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(obj, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            //projectile.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            projectile.GetComponent<ProjectileDamage>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
