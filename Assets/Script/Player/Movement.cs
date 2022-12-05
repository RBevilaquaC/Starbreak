using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Parameters

    
    [SerializeField] private float speedModifier;
    [SerializeField] private float rotateModifier;
    private Rigidbody2D rb;
    private Vector2 dirToMove;
    private Vector2 inputDir;
    private Vector2 inputDirLast;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputDirLast = Vector2.zero;
    }

    private void Update()
    {
        inputDir.x = Input.GetAxis("Horizontal");
        inputDir.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        MoveSpaceship();
        RotateSpaceship();
    }

    private void MoveSpaceship()
    {
        if(inputDir != Vector2.zero)
        {
            rb.velocity = inputDir.normalized * speedModifier;
            inputDirLast = inputDir;
        }
    }

    private void RotateSpaceship()
    {
        Vector2 currentPos = Camera.main.WorldToViewportPoint (transform.position);
        Vector2 mousePos = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(currentPos, mousePos);
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler (new Vector3(0f,0f,angle+90)), rotateModifier);
        //transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle+90));
    }
    
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
