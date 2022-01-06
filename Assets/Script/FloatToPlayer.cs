using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatToPlayer : MonoBehaviour
{
    private GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }
}
