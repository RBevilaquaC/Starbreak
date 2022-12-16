using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AuxGunControl : MonoBehaviour
{
    #region Parameters

    [SerializeField] private float turnModifier;
    [SerializeField] private float speedBulletModifier;
    [SerializeField] private float cdShoot;
    private Transform auxGunPivot;
    private float timerCDShoot;
    private int sideGun;

    #endregion

    private void Start()
    {
        auxGunPivot = transform.GetChild(0);
        sideGun = 1;
    }

    private void Update()
    {
        lookToPlayer();
        if(timerCDShoot <= 0)
        {
            RequestShoot();
            timerCDShoot = cdShoot;
        }
        else if (timerCDShoot >= 0) timerCDShoot -= Time.deltaTime;
    }

    private void lookToPlayer()
    {
        Vector3 mousePosition = PlayerStatus.playerObject.transform.position;
        Vector3 direction = mousePosition - auxGunPivot.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle-90);
        auxGunPivot.rotation = (Quaternion.Lerp(auxGunPivot.rotation, Quaternion.Euler(targetRotation), turnModifier));
    }
    
    protected void RequestShoot()
    {
        
        GameObject bullet = EnemyBulletPool.enemyBulletPool.DeliveryBullet();
        bullet.GetComponent<Bullet>().owner = gameObject;
        float angle = auxGunPivot.rotation.eulerAngles.z+90;
        Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0);
        Vector3 dirSide = new Vector3(Mathf.Cos((angle-90) * Mathf.Deg2Rad), Mathf.Sin((angle-90) * Mathf.Deg2Rad),0);
        bullet.transform.position = auxGunPivot.position + dir*0.2f + dirSide * (0.1f * sideGun);
        sideGun *= -1;
        
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = dir * speedBulletModifier;
    }

}
