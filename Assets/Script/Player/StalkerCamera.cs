using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerCamera : MonoBehaviour
{
     public Transform player;
     public Vector3 offset;

     public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        //Vector3 desiredPosition = player.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, player.position, smoothSpeed);
        //transform.position = smoothedPosition;
        //transform.LookAt(player);
        //transform.position = Vector2.Lerp(transform.position, player.position, 2f);
    }
}
