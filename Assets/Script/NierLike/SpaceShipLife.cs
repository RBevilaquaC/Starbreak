using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipLife : MonoBehaviour
{
    private int maxLife = 2;
    protected int currentLife;
    // Start is called before the first frame update
    void Awake()
    {
        currentLife = maxLife;
    }

    public void TakeDamage()
    {
        currentLife--;
        transform.GetChild(currentLife+2).gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
