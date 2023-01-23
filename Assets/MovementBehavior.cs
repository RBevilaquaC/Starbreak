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

    private void Start()
    {
        transformShip =transform;
        rotationShip = transformShip.rotation;
        positionShip = transformShip.position;
        zPosShip = rotationShip.eulerAngles.z;
    }

    private void FixedUpdate()
    {
        RotationShip();
        MovementSHip();
    }

    private void RotationShip()
    {
        float x = Input.GetAxis("Horizontal");

        if (x > 0)
        {
            print("propulsor dianteiro: Esquerda || propulsor traseiro: Direita");
        }

        if (x < 0)
        {
            print("propulsor dianteiro: Direita || propulsor traseiro: Esquerda");
        }
        
        zPosShip -= x * rotSpeed * Time.deltaTime;
        rotationShip = Quaternion.Euler(0,0,zPosShip);
        transform.rotation = rotationShip;
        
    }

    private void MovementSHip()
    {
        float x = Input.GetAxis("Vertical");

        if (x > 0)
        {
            acelerationShip = new Vector3(0, x * maxSpeed * Time.deltaTime, 0);
            positionShip += rotationShip * acelerationShip;
            transform.position = positionShip;
        }

        if (x < 0)
        {
            x /= 2;
            acelerationShip = new Vector3(0, x * maxSpeed * Time.deltaTime, 0);
            positionShip += rotationShip * acelerationShip;
            transform.position = positionShip;
        }
    }

}
