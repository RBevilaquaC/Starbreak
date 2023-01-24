using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotSpeed;

    private Transform transformShip;
    private Quaternion rotationShip;
    private float zPosShip;
    private Vector3 positionShip;
    private Vector3 acelerationShip;

    private float horiz;
    private float vert;

    private void Start()
    {
        transformShip =transform;
        rotationShip = transformShip.rotation;
        positionShip = transformShip.position;
        zPosShip = rotationShip.eulerAngles.z;
    }

    private void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        RotationShip();
        MovementSHip();
    }

    private void RotationShip()
    {

        if (horiz > 0)
        {
            print("propulsor dianteiro: Esquerda || propulsor traseiro: Direita");
        }

        if (horiz < 0)
        {
            print("propulsor dianteiro: Direita || propulsor traseiro: Esquerda");
        }
        
        zPosShip -= horiz * rotSpeed * Time.deltaTime;
        rotationShip = Quaternion.Euler(0,0,zPosShip);
        transform.rotation = rotationShip;
        
    }

    private void MovementSHip()
    {

        if (vert > 0)
        {
            acelerationShip = new Vector3(0, vert * maxSpeed * Time.deltaTime, 0);
            positionShip += rotationShip * acelerationShip;
            transform.position = positionShip;
        }

        if (vert < 0)
        {
            acelerationShip = new Vector3(0, (vert/2) * maxSpeed * Time.deltaTime, 0);
            positionShip += rotationShip * acelerationShip;
            transform.position = positionShip;
        }
    }

}
