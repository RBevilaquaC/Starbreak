using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    #region Parameters

    public static GameObject playerObject;

    #endregion

    private void Awake()
    {
        playerObject = gameObject;
    }
}
