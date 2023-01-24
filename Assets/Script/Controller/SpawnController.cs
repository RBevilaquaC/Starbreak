using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnController : MonoBehaviour
{
    #region Parameters

    [Header("General Settings")]
    [SerializeField] private float timeToStart;
    private GameObject lancer;
    private float timeElapsed;

    [Header("Hammer Settings")]
    [SerializeField] private GameObject hammer;
    [SerializeField] private int hammerTimeIncrement;
    [SerializeField] private int initialHammerQuantity;
    private Transform hammerParent;
    private int hammerCount;
    private int hammerActiveCount;
    
    [Header("Spear Settings")]
    [SerializeField] private GameObject spear;
    [SerializeField] private float spearTimeIncrement;
    [SerializeField] private float initialSpearQuantity;
    private Transform spearParent;
    private int spearCount;
    private int spearActiveCount;
    
    #endregion

    private void Start()
    {
        hammerParent = transform.GetChild(0).GetChild(0);
        spearParent = transform.GetChild(0).GetChild(1);
    }

    private void FixedUpdate()
    {
        if (timeToStart > 0) timeToStart -= Time.fixedDeltaTime;
        else
        {
            timeElapsed += Time.fixedDeltaTime;
            SpawnHammer();
            SpawnSpear();
        }
    }

    #region SpawnnerFunctions

    private void SpawnHammer()
    {
        for (; hammerCount < (timeElapsed / hammerTimeIncrement) + initialHammerQuantity; hammerCount++)
        {
            Vector3 playerPos = PlayerStatus.playerObject.transform.position;
            GameObject newHammer = Instantiate(hammer, hammerParent);
            newHammer.transform.position = playerPos +
                                           (new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0).normalized)*20;
        }
    }

    private void SpawnSpear()
    {
        for (; spearCount < (timeElapsed / spearTimeIncrement) + initialSpearQuantity; spearCount++)
        {
            Vector3 playerPos = PlayerStatus.playerObject.transform.position;
            GameObject newSpear = Instantiate(spear, spearParent);
            newSpear.transform.position = playerPos +
                                          (new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0).normalized)*20;
        }
    }

    #endregion
    
}
