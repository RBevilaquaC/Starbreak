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
    [SerializeField] private float rotateModifier;
    private ParticleSystem ps;

    private float timerCDShoot;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        var mainModule = ps.main;
        mainModule.duration = cdShoot;
    }

    private void FixedUpdate()
    {
        RotateCannon();
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
    private void RotateCannon()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle-90);
        transform.rotation = (Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), rotateModifier));
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
