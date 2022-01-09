using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator animator;
    private bool facingRight;

    private void Start()
    {
        animator = GetComponent<Animator>();
        facingRight = true;

    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            TakeInput();
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        transform.position = new Vector2(
                Mathf.Clamp(transform.position.x, -31.25f, 31.25f),
                Mathf.Clamp(transform.position.y, -16.5f, 17.5f));
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
        }
        else if (!Input.anyKey)
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            //Flip(false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            //Flip(true);
        }
    }

    void Flip(bool direction)
    {
        if (direction != facingRight)
        {
            facingRight = direction;

            // Multiply the player's x local scale by -1
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
