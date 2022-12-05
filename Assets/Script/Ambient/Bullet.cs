using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool init = true;

    private void OnEnable()
    {
        if (init) init = false;
        else Invoke("Disable", 5);
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
