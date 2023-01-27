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
        gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Transform guns = transform.Find("Guns");
        transform.Find("Explosion").GetComponent<ParticleSystem>().Play();
        
        foreach (Transform childs in guns)
        {
            var emissionModule = childs.GetComponent<ParticleSystem>().emission;
            emissionModule.rateOverTime = 0;
            Debug.Log("Funcionou");
            
        }
        Destroy(gameObject, 3f);
        //other.GetComponentInChildren<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
