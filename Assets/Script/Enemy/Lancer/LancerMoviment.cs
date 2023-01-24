using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LancerMoviment : EnemyBasicMovements
{
    #region Parameters

    [SerializeField] private float distToStay;
    [SerializeField] private int countToShoot;
    [SerializeField] private float chargingCd;
    private float timerChargingCd;
    private Transform playerTransform;
    private Animator anim;
    
    private bool charging;
    private int currentCountToShoot;
    public bool endAnimationCharging;

    #endregion

    private void Start()
    {
        playerTransform = PlayerStatus.playerObject.transform;
        anim = GetComponent<Animator>();
        charging = false;
    }
    
    private void FixedUpdate()
    {
        lookToPlayer();
        float distToPlayer = (transform.position - playerTransform.position).magnitude;
        if ((distToPlayer <= distToStay || charging) && timerChargingCd >= chargingCd)
        {
            Stay();
            ChargeMainGun();
        }else if (distToPlayer > distToStay)
        {
            anim.Play($"SpeedLancer");
            MoveFoward();
        }else if (distToPlayer < distToStay)
        {
            anim.Play($"SpeedLancer");
            MoveBack();
        }

        if (timerChargingCd < chargingCd) timerChargingCd += Time.deltaTime;
    }

    private void ChargeMainGun()
    {
        anim.Play($"ChargeLancer");
        charging = true;
        if (endAnimationCharging) currentCountToShoot++;
        if (currentCountToShoot >= countToShoot)
        {
            charging = false;
            currentCountToShoot = 0;
            timerChargingCd = 0;
        }
    }
    
}
