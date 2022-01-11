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
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
        StartCoroutine(TrackPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        var localVelocity = transform.InverseTransformDirection(obj.GetComponent<Rigidbody2D>().velocity);
        if (localVelocity.x < 0 && facingRight)
        {
            facingRight = false;

            // Multiply the player's x local scale by -1
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        } else if (localVelocity.x > 0 && !facingRight)
        {
            facingRight = true;

            // Multiply the player's x local scale by -1
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
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

            StartCoroutine(TrackPlayer());
        }


    }
}
