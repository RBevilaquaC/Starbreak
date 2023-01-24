using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NierBulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject bulletCollision;
    [SerializeField]private float cdShoot;
    private ParticleSystem ps;

    private float timerCDShoot;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        var mainModule = ps.main;
        //mainModule.duration = cdShoot;
    }

    private void Update()
    {

        if(Input.GetButton("Fire1") && timerCDShoot <= 0)
        {
            ps.Play();
            timerCDShoot = cdShoot;
        }
        else if (timerCDShoot >= 0) timerCDShoot -= Time.deltaTime;
    }

    private void OnParticleCollision(GameObject other)
    {
        //ParticlePhysicsExtensions.GetCollisionEvents;
        
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<LifeSystem>().takeDamage(1);
            GameObject particleSystem = Instantiate(bulletCollision, other.transform.position, Quaternion.identity);
            Destroy(particleSystem, 1f);
        }
        //Transform child = transform.Find("Explosion");
        //other.SetActive(false);
    }
}
