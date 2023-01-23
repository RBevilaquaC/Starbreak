using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMoviment : EnemyBasicMovements
{
    #region Parameters

    [SerializeField] protected float speedBulletModifier;
    [SerializeField] protected float cdShoot;
    [SerializeField] protected float distToStay;
    protected float timerCDShoot;

    #endregion
    
    private void Update()
    {
        if(timerCDShoot <= 0)
        {
            RequestShoot();
            timerCDShoot = cdShoot;
        }
        else if (timerCDShoot >= 0) timerCDShoot -= Time.deltaTime;
    }
    
    protected void RequestShoot()
    {
        
        GameObject bullet = EnemyBulletPool.enemyBulletPool.DeliveryBullet();
        bullet.GetComponent<Bullet>().owner = gameObject;
        float angle = transform.rotation.eulerAngles.z+90;
        Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0);
        bullet.transform.position = transform.position + dir*0.5f;
        
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = dir * speedBulletModifier;
    }

    
    private void FixedUpdate()
    {
        lookToPlayer();
        if(DirToPlayer() > distToStay)
            MoveFoward();
        else MoveToSide();
    }
}
