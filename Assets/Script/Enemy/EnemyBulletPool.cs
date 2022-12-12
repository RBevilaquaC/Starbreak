using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    #region Parameters

    public static EnemyBulletPool enemyBulletPool;
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject enemyBulletDefault;
    private int currentBullet;

    #endregion

    private void Awake()
    {
        enemyBulletPool = this;
        fillPool(poolSize);
    }

    private void fillPool(int bulletAmount)
    {
        for (;bulletAmount>0;bulletAmount--)
        {
            GameObject newProjectPrefab = Instantiate(enemyBulletDefault, gameObject.transform);
            newProjectPrefab.SetActive(false);
        }
    }

    public GameObject DeliveryBullet()
    {
        GameObject currentBulletToDelivery = transform.GetChild(currentBullet).gameObject;
        currentBullet++;
        currentBullet %= poolSize;
        return currentBulletToDelivery;
    }
}
