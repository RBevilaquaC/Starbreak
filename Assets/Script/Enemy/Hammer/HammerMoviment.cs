using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMoviment : MonoBehaviour
{
    #region Parameters

    [SerializeField] private float speedModifier;
    [SerializeField] private float turnModifier;

    #endregion

    private void FixedUpdate()
    {
        lookToPlayer();
        MoveFoward();
    }

    private void lookToPlayer()
    {
        Vector3 mousePosition = PlayerStatus.playerObject.transform.position;
        Vector3 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle-90);
        transform.rotation = (Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), turnModifier));
    }
    
    
    private void MoveFoward()
    {
        float angle = transform.rotation.eulerAngles.z+90;
        Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0);
        GetComponent<Rigidbody2D>().velocity = dir * speedModifier;
    }
}
