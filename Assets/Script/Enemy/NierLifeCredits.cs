using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class NierLifeCredits : LifeSystem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Death()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("Morreu");
        foreach (Transform childs in transform)
        {
            if (childs.GetComponent<NierBulletCollision>() != null)
            {
                var emissionModule = childs.GetComponent<ParticleSystem>().emission;
                emissionModule.rateOverTime = 0;
                Debug.Log("Funcionou");
            }
            else
            {
                childs.GetComponent<ParticleSystem>().Play();
            }
        }
        Destroy(gameObject, 3f);
        //other.GetComponentInChildren<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
