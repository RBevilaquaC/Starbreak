using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    #region Parameters

    private Transform playerPos;
    private Vector3 offset;
    [SerializeField] private float smoothIntensity;

    #endregion

    private void Start()
    {
        playerPos = PlayerStatus.playerObject.transform;
        offset = new Vector3(0, 0, -10);
        transform.position = playerPos.position + offset;
    }

    private void LateUpdate()
    {
        FollowPlayerSmoothMovements();
    }

    private void FollowPlayerSmoothMovements()
    {
        Vector3 target = playerPos.position + offset;
        transform.position = Vector3.Lerp(target, transform.position, smoothIntensity);
    }

    private void ShakeScreen()
    {
        Vector3 shakeTgt = new Vector3(Random.value, Random.value, 0) + offset;
        transform.position = Vector3.Lerp(shakeTgt, transform.position, 0.8f);

    }
}
