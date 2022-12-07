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
    private Camera _camera;

    #endregion

    private void Start()
    {
        _camera = Camera.main;
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle-90);
        transform.rotation = (Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), rotateModifier));
    }
}
