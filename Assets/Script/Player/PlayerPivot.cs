using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPivot : MonoBehaviour
{
    public GameObject player;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        difference.Normalize();

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        // Facing left
        if (rotationZ < -90 || rotationZ > 90)
        {
            // Check if still facing right
            if (facingRight)
            {
                // Flip player
                FlipPlayer();

                facingRight = false;
            }

            if (player.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, rotationZ);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, rotationZ);
            }
        }
        else
        {
            if (!facingRight)
            {
                FlipPlayer();

                facingRight = true;
            }
        }
    }

    public void FlipPlayer()
    {
        Vector3 playerScale = player.transform.localScale;
        playerScale.x *= -1;
        player.transform.localScale = playerScale;

        Vector3 handScale = transform.localScale;
        handScale.x *= -1;
        transform.localScale = handScale;
    }
}
