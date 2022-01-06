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
            //float minPositionX = -20;
            //float maxPositionX = 20;
            //float minPositionY = -15;
            //float maxPositionY = 15;

            //Vector3 positionMax = new Vector3(
            //    Mathf.Clamp(player.transform.position.x, minPositionX, maxPositionX),
            //    Mathf.Clamp(player.transform.position.y, minPositionY, maxPositionY),
            //    transform.position.z);

            Vector3 newPosition = Vector3.Lerp(positionMax, player.transform.position + offset, smoothing);
            transform.position = newPosition;
        }
    }
}
