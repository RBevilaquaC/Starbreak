using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class LifeSystem : MonoBehaviour
{
    #region Parameters

    [SerializeField] protected int maxLife;
    [SerializeField] protected GameObject floatingTextPrefab;
    protected int currentLife;

    #endregion

    private void Awake()
    {
        currentLife = maxLife;
    }

    public virtual void takeDamage(int damgeAmount)
    {
        currentLife -= damgeAmount;
        Debug.Log("Tomou dano");
        ShowDamage(damgeAmount.ToString());
        if(currentLife <= 0) Death();
    }
    
    private void ShowDamage(string damage){
        if (floatingTextPrefab)
        {
            GameObject textPrefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            textPrefab.GetComponentInChildren<TextMeshPro>().text = damage;
            Destroy(textPrefab, 0.7f);
        }
    
    }

    public virtual void Death()
    {
        gameObject.SetActive(false);
    }

    private void Heal(int healAmount)
    {
        currentLife += healAmount;
        if (currentLife > maxLife) currentLife = maxLife;
    }
}
