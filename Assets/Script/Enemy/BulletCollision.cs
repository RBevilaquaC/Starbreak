using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (!other.CompareTag("Player")) return;
        Debug.Log("Acertou Miserável");
        other.TryGetComponent(out LifeSystem currentLife);
        currentLife.takeDamage(2);
        
    }
}
