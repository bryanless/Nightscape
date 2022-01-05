using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject obj;
    public float speed;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 myPos = transform.position;
        //Vector2 targetPos = player.transform.position;
        //Vector2 direction = (targetPos - myPos).normalized;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        //movement = direction;
        //obj.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
