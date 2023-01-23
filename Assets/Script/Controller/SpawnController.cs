using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnController : MonoBehaviour
{
    #region Parameters

    [SerializeField] private GameObject hammer;
    [SerializeField] private GameObject spear;
    private GameObject lancer;
    private int hammerCount;
    private int hammerActiveCount;
    private int spearCount;
    private int spearActiveCount;
    private Transform hammerParent;
    private Transform spearParent;
    [SerializeField] private int hammerTimeIncrement;

    #endregion

    private void Start()
    {
        hammerParent = transform.GetChild(0).GetChild(0);
        spearParent = transform.GetChild(0).GetChild(1);
    }

    private void FixedUpdate()
    {
        spawnHammer();
    }

    private void spawnHammer()
    {
        for (; hammerCount < (Time.timeSinceLevelLoad / hammerTimeIncrement) + 2; hammerCount++)
        {
            Vector3 playerPos = PlayerStatus.playerObject.transform.position;
            GameObject newHammer = Instantiate(hammer, hammerParent);
            newHammer.transform.position = playerPos +
                                           (new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0).normalized)*20;
        }
    }
    
}
