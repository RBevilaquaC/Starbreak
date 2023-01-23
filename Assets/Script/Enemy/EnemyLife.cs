using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : LifeSystem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Death(){
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        foreach (Transform childs in transform)
                {
                    var emissionModule = childs.GetComponent<ParticleSystem>().emission;
                    emissionModule.rateOverTime = 0;
                    
                }
                Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
