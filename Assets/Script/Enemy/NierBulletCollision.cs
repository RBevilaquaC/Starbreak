using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NierBulletCollision : MonoBehaviour
{
    // Start is called before the first frame updat]
    private void OnParticleCollision(GameObject other)
    {
        other.GetComponentInChildren<ParticleSystem>().Play();
        //other.SetActive(false);
        Destroy(other, 0.25f);
    }
}
