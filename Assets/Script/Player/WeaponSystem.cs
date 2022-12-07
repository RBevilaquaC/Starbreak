using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    #region Parameters

    [SerializeField] private GameObject bulletDefault;
    [SerializeField] private Transform bulletPool;
    [SerializeField] private int poolSize;
    [SerializeField] private float speedBulletModifier;
    [SerializeField] private float cdShoot;
    private int sideGun = 1;
    private float timerCDShoot;
    private int currentBullet;
    
    #endregion

    private void Start()
    {
        InitPool(poolSize);
    }
    
    private void Update()
    {
        if(Input.GetButton("Fire1") && timerCDShoot <= 0)
        {
            Shoot();
            timerCDShoot = cdShoot;
        }
        else if (timerCDShoot >= 0) timerCDShoot -= Time.deltaTime;
    }

    private void InitPool(int amount)
    {
        for (;amount>0;amount--)
        {
            GameObject newProjectPrefab = Instantiate(bulletDefault, bulletPool);
            newProjectPrefab.SetActive(false);
        }
    }

    private void Shoot()
    {
        GameObject bullet = bulletPool.GetChild(currentBullet).gameObject;
        float angle = transform.rotation.eulerAngles.z+90;
        Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0);
        Vector3 dirSide = new Vector3(Mathf.Cos((angle-90) * Mathf.Deg2Rad), Mathf.Sin((angle-90) * Mathf.Deg2Rad),0);
        bullet.transform.position = transform.position + dir*0.5f + dirSide * (0.4f * sideGun);
        sideGun *= -1;
        
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = dir * speedBulletModifier;
        
        currentBullet++;
        currentBullet %= poolSize;
    }

}
