using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool init = true;
    public GameObject owner;
    
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != owner)
        {
            col.gameObject.GetComponent<LifeSystem>().takeDamage(1);
            gameObject.SetActive(false);
        }
    }
}
