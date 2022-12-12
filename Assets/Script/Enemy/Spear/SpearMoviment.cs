using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMoviment : MonoBehaviour
{
    #region Parameters

    [SerializeField] private float speedModifier;
    [SerializeField] private float turnModifier;
    [SerializeField] private float speedBulletModifier;
    [SerializeField] private float cdShoot;
    [SerializeField] private float distToStay;
    private float timerCDShoot;

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

    private void RequestShoot()
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

    private float DirToPlayer()
    {
        return (PlayerStatus.playerObject.transform.position - transform.position).magnitude;
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
    
    private void MoveToSide()
    {
        float angle = transform.rotation.eulerAngles.z;
        Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0);
        GetComponent<Rigidbody2D>().velocity = dir * speedModifier;
    }

    
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<LifeSystem>().takeDamage(10);
        }
    }
}
