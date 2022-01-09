using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            float minPositionX = -23f;
            float maxPositionX = 23f;
            float minPositionY = -13f;
            float maxPositionY = 13;

            Vector3 positionMax = new Vector3(
                Mathf.Clamp(player.transform.position.x, minPositionX, maxPositionX),
                Mathf.Clamp(player.transform.position.y, minPositionY, maxPositionY),
                transform.position.z);

            Vector3 newPosition = Vector3.Lerp(transform.position, positionMax + offset, smoothing);
            transform.position = newPosition;
        }
    }
}
