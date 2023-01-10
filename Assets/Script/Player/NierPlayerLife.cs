using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NierPlayerLife : LifeSystem
{
    // Start is called before the first frame update
    void Start()
    {
        maxLife = 3;
    }

    public override void takeDamage(int damgeAmount)
    {
        base.takeDamage(1);
        Debug.Log((currentLife - 1).ToString());
        if (currentLife <= 0) return;
        Destroy(transform.GetChild(currentLife - 1).gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
