using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    #region Parameters

    [SerializeField] protected int maxLife;
    protected int currentLife;

    #endregion

    private void Awake()
    {
        currentLife = maxLife;
    }

    public virtual void takeDamage(int damgeAmount)
    {
        currentLife -= damgeAmount;
        if(currentLife <= 0) Death();
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }

    private void Heal(int healAmount)
    {
        currentLife += healAmount;
        if (currentLife > maxLife) currentLife = maxLife;
    }
}
