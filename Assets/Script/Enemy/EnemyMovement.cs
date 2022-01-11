using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject obj;
    public float speed;
    private float cooldownMovement;
    private Animator animator;
    //private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
        StartCoroutine(TrackPlayer());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator TrackPlayer()
    {
        cooldownMovement = Random.Range(1, 4);
        if (player != null)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = player.transform.position;
            Vector3 direction = (targetPos - myPos).normalized;

            if (Vector3.Magnitude(targetPos - myPos) < 0.05)
            {
                direction = Vector3.zero;
            }

            obj.GetComponent<Rigidbody2D>().velocity = direction * speed;
            animator.SetBool("isWalking", true);
            yield return new WaitForSeconds(cooldownMovement);
            direction = Vector3.zero;
            obj.GetComponent<Rigidbody2D>().velocity = direction * speed;
            animator.SetBool("isWalking", false);
            yield return new WaitForSeconds(cooldownMovement);

            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            //movement = direction;

            StartCoroutine(TrackPlayer());
        }


    }
}
