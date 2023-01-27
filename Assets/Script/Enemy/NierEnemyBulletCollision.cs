using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NierEnemyBulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject bulletCollision;
    private void OnParticleCollision(GameObject other)
    {
        //ParticlePhysicsExtensions.GetCollisionEvents;
        Debug.Log("Acertou o player");
        if (other.CompareTag("Player"))
        {
            Transform playerLife = other.transform.Find("LifeContainer");
            playerLife.GetComponent<NierPlayerLife>().takeDamage(1);
            //other.GetComponent<NierPlayerLife>().takeDamage(1);
            //GameObject particleSystem = Instantiate(bulletCollision, other.transform.position, Quaternion.identity);
        }
        //Transform child = transform.Find("Explosion");
        //other.SetActive(false);
    }
}
