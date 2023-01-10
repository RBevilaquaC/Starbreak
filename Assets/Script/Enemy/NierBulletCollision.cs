using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NierBulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject bulletCollision;
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
